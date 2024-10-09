// <copyright file="ToDoMsSqlDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.DataBase
{
    using System.Reflection;
    using ASPWebAPITemplate.Models;
    using Microsoft.EntityFrameworkCore;

#pragma warning disable SA1600
    public class ToDoMsSqlDbContext : DbContext
    {
        public ToDoMsSqlDbContext(DbContextOptions<ToDoMsSqlDbContext> options) // , IConfiguration configuration)
            : base(options)
        {
        }

        public DbSet<ToDoTask>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity<ToDoTask>(entity =>
            {
                entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(entity.Property<int>("Id"));

                entity.Property<string>("TaskID")
                .HasColumnType("nchar(10)");

                entity.Property("TaskName")
                .HasColumnType("nchar(10)");

                entity.Property("StartDate")
                .HasColumnType("datetime");

                entity.Property("EndDate")
                .HasColumnType("datetime");

                entity.Property("Status")
                .HasColumnType("nchar(10)");

                entity.HasKey("Id");

                entity.ToTable("ToDoTasks");
            });
        }
    }
#pragma warning restore SA1600
}
