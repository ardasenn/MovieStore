using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Token
{
    public class TokenGenerator : ITokenGeneratorService
    {
        private readonly IConfiguration configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Application.DTOs.Token CreateAccesToken(int second, Customer customer)
        {
            Application.DTOs.Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(second);

            JwtSecurityToken securityToken = new(
                audience: configuration["Token:Issuer"],
                issuer: configuration["Token:Issuer"],
                expires: token.Expiration,                
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Email, customer.Email) }
                );
            JwtSecurityTokenHandler tokenHandler = new();

            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken(customer.Email);
            return token;
        }
        public string CreateRefreshToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {Audience= configuration["Token:Issuer"],
            Issuer= configuration["Token:Issuer"],
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:RefreshKey"])), SecurityAlgorithms.HmacSha256)
            };

            var refreshToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(refreshToken);

        }
    }


}
