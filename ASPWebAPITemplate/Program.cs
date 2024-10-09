// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate
{
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using ASPWebAPITemplate.DataBase;
    using ASPWebAPITemplate.Extensions;
    using ASPWebAPITemplate.JWT;
    using ASPWebAPITemplate.Mapping;
    using ASPWebAPITemplate.Repository;
    using FluentValidation;
    using Hellang.Middleware.ProblemDetails;
    using MediatR;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

#pragma warning disable SA1600
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("ef connection string error");
            builder.Services.AddDbContext<ToDoMsSqlDbContext>(options =>
            {
                options.UseSqlServer(dbConnection);
            });

            builder.Services.AddHealthChecks()
                .AddDbContextCheck<ToDoMsSqlDbContext>()
                .AddSqlServer(dbConnection);

            builder.Services.AddSingleton<IMapper, Mapper>();

            builder.Services.AddScoped<ToDoMsSqlDbRepository>();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                    };
                });

            builder.Services.AddProblemDetails();

            builder.Services.AddLocalization();

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddControllers();

            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        Array.Empty<string>()
                    },
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler("/error");

            var supportCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("uk"),
                SupportedCultures = supportCultures,
                SupportedUICultures = supportCultures,
                ApplyCurrentCultureToResponseHeaders = true,
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks();

            app.Run();
        }
    }
#pragma warning restore SA1600
}