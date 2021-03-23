using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MOP.Calculator.Service.Command
{
    public interface ICalculatorCommand
    {
        IEnumerable<double> ExecuteCalculator(Assembly assembly);
        IEnumerable<double> LoadCalculator(string path);
    }
}
