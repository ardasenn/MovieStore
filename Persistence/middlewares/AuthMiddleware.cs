using System.Net;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Persistence.middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public AuthMiddleware(RequestDelegate _next, IConfiguration configuration)
        {
            next = _next;
            this.configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("Auth"))
            {
                await next(context);
                return;
            }

            var refreshToken = context.Request.Headers["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken) || !ValidateRefreshToken(refreshToken))
            {
                await UnAuth(context);
                return;
            }

            var accessToken = context.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(accessToken) || !ValidateAccessToken(accessToken))
            {
                await UnAuth(context);
                return;
            }

            string email = GetEmailFromClaims(refreshToken);
            context.Items["Email"] = email;
            await next(context);
        }

        private bool ValidateRefreshToken(string refreshToken)
        {
            try
            {
                var securityRefreshKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:RefreshKey"]));
                var tokenRefreshHandler = new JwtSecurityTokenHandler();
                var tokenRefreshValidationParameters = GetTokenValidationParameters(securityRefreshKey);

                tokenRefreshHandler.ValidateToken(refreshToken, tokenRefreshValidationParameters, out _);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidateAccessToken(string accessToken)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = GetTokenValidationParameters(securityKey);

                tokenHandler.ValidateToken(accessToken.Split("Bearer ")[1], tokenValidationParameters, out _);
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                // TODO generate token
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private TokenValidationParameters GetTokenValidationParameters(SecurityKey securityKey)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = true,
                ValidAudience = configuration["Token:Issuer"],
                ValidIssuer = configuration["Token:Issuer"],
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
            };
        }

        private string GetEmailFromClaims(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:RefreshKey"]));
            var tokenValidationParameters = GetTokenValidationParameters(securityKey);

            var claimsPrincipal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out _);

            return claimsPrincipal?.Claims.First(claim => claim.Type == ClaimTypes.Email)?.Value;
        }

        private static async Task UnAuth(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
