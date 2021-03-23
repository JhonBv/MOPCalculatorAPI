using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Configuration
{
    public interface IPluginConfigurationWrapper
    {
        string getStorePluginPath(string context);
    }
}
