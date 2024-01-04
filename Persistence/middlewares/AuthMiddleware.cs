using System.Net;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
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
            if (!context.Request.Path.ToString().Contains("Auth"))
            {
                await next(context);
                return;
            }
            var refreshToken = context.Request.Headers["refresh-token"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                await UnAuth(context);
                return;
            }
            string accessTokenString = context.Request.Headers["Authorization"];

            var token = accessTokenString.Split("Bearer ")[1];
            if (string.IsNullOrEmpty(token))
            {
                await UnAuth(context);
                return;
            }

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = true,
                ValidAudience = configuration["Token:Issuer"],
                ValidIssuer = configuration["Token:Issuer"],
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireExpirationTime = false,
            };
            ClaimsPrincipal claimsPrincipal = null;
            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            }
            catch (SecurityTokenExpiredException)
            {
                //
            }
            catch (Exception ex)
            {
                await UnAuth(context);
                return;
            }

            string email = claimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            context.Items["Email"] = email;
            await next(context);
        }

        private static async Task UnAuth(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}