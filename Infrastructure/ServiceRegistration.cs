﻿using Application.Services;
using Infrastructure.Services.Logger;
using Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<ITokenGeneratorService, TokenGenerator>();
        }
    }
}
