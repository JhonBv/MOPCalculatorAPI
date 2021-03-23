
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Services
{
    public interface IPluginLoaderService
    {
        Assembly LoadPlugin(string path);

    }
}
