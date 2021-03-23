using MOP.PluginContracts;
using MOP.PluginManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Services
{
    public class PluginLoaderService : IPluginLoaderService
    {
        private ILoggerManager _logger;
        public PluginLoaderService(ILoggerManager logger)
        {
            _logger = logger;
        }
        public Assembly LoadPlugin(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            string v = Path.GetFullPath(Path.Combine(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(
                                    Path.GetDirectoryName(
                                        Path.GetDirectoryName(
                                            Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));
            var root = v;
            string v1 = Path.GetFullPath(Path.Combine(root, path.Replace('\\', Path.DirectorySeparatorChar)));
            string pluginLocation = v1;
            _logger.LogInfo($"Loading plugin from: {pluginLocation}");

            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            loadContext.GetType();
            Assembly assembly = loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
            var loaded = assembly;
            return loaded;
        }
    }
}
