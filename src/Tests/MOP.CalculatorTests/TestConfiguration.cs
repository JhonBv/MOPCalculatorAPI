using Microsoft.Extensions.DependencyInjection;
using MOP.Calculator.API.Services;

namespace MOP.CalculatorTests
{
    /// <summary>
    /// Configure Dependency Injection so Interfaces can be Injected during Unit Testing
    /// </summary>
    public class TestConfiguration
    {
        public ServiceCollection services;
        public TestConfiguration()
        {
            services = new ServiceCollection();
            ConfigureDi();
        }
        public ServiceCollection returnServiceCollection()
        {
            return services;
        }
        public void ConfigureDi()
        {
            services.AddSingleton<IPluginLoaderService, PluginLoaderService>();
            services.AddSingleton<ICalculatorService, CalculatorService>();
        }
    }
}
