using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Configuration
{
    /// <summary>
    /// Root Plugin Store configuration. The value can be any URL (local path, Web URI, etc)
    /// </summary>
    public class PluginConfigurationWrapper : IPluginConfigurationWrapper
    {
        private readonly PluginStoreConfiguration _config;
        /// <summary>
        /// Configuration class for the Calculator PluginStore
        /// </summary>
        /// <param name="config"></param>
        public PluginConfigurationWrapper(IOptions<PluginStoreConfiguration> config)
        {
            _config = config.Value;
        }
        public string getStorePluginPath(string context)
        {
            return _config.PluginPath;
        }
    }
}
