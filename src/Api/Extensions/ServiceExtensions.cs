using Microsoft.Extensions.DependencyInjection;
using MOP.Calculator.API.Services;
using MOP.Calculator.Services;
using MOP.PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManagerService>();
        }
        public static void ConfigureCalculatorServices(this IServiceCollection services)
        {
            services.AddSingleton<ICalculatorService, CalculatorService>();
            services.AddSingleton<IPluginLoaderService, PluginLoaderService>();
        }
    }
}
