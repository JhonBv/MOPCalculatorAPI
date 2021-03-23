
using Microsoft.Extensions.Logging;
using MOP.Calculator.API.Configuration;
using MOP.Calculator.Models;
using MOP.PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Services
{
    /// <summary>
    /// Provides Calculator function access to Calculator plugins
    /// </summary>
    public class CalculatorService:ICalculatorService
    {
        private IPluginLoaderService _pluginLoader;
        private readonly ILoggerManager _logger;
        private readonly IPluginConfigurationWrapper _config;
        /// <summary>
        /// Initialize Calculator Service
        /// </summary>
        /// <param name="pluginLoader"></param>
        /// <param name="logger"></param>
        /// <param name="config"></param>
        public CalculatorService(IPluginLoaderService pluginLoader, ILoggerManager logger, IPluginConfigurationWrapper config)
        {
            _pluginLoader = pluginLoader;
            _logger = logger;
            _config = config;
        }
        /// <summary>
        /// Excecute the Calculator Plugin
        /// </summary>
        /// <param name="path">Specifies Plugin location</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public double ExecuteCalculator(string path, CalculatorInputModel input)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            Assembly pluginAssembly = _pluginLoader.LoadPlugin(path);
            double result = 0.0;
            if (!String.IsNullOrEmpty(pluginAssembly.FullName))
            {
                result = LoadCalculator(pluginAssembly, input);
            }
            return result;
        }

        /// <summary>
        /// Loads the registered Calculator Types from passsed Assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public double LoadCalculator(Assembly assembly, CalculatorInputModel input)
        {
            Type type = assembly.GetType("CSharpCalculatorPlugin.Calculator");
            Type loadedType = type;
            if (loadedType != null)
            {
                dynamic calcInstance = Activator.CreateInstance(loadedType);
                var result = calcInstance.Calculate(input.Operation, input.FirstNumber, input.SecondNumber);
                _logger.LogInfo("Loging calculation result for operation "+ input.Operation.ToString()+ " " +result);
                return result;
            }

            return 0.0;
        }
    }
}
