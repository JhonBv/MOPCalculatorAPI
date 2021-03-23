using System;
using System.Reflection;
using System.Runtime.Loader;

namespace MOP.PluginManager
{
    /// <summary>
    /// Loads available Assemblies (plugins) from the location provided
    /// https://github.com/dotnet/samples/blob/main/core/extensions/AppWithPlugin/AppWithPlugin/PluginLoadContext.cs
    /// </summary>
    public class PluginLoadContext: AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        public PluginLoadContext(string pluginPath)
        {
            if (pluginPath is null)
            {
                throw new ArgumentNullException(nameof(pluginPath));
            }

            _resolver = new AssemblyDependencyResolver(pluginPath);
        }
        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }
            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }


    }
}
