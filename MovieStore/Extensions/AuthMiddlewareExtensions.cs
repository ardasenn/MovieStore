using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.middlewares;

namespace MovieStore.Extensions
{
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}