// <copyright file="AuthService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.JWT
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using ASPWebAPITemplate.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

#pragma warning disable SA1600
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;

        private readonly User user = new() { UserName = "Max", Password = "123" };

        public AuthService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string TryToLogin(User user)
        {
            if (user == null || user.UserName.Length == 0 || user.Password.Length == 0 || user.UserName != this.user.UserName || user.Password != this.user.Password)
            {
                return string.Empty;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),

                // new Claim(ClaimTypes.Name, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: this.configuration["Jwt:Issuer"],
                audience: this.configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
#pragma warning restore SA1600
}
