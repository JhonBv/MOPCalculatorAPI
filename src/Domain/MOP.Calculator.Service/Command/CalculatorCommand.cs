using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MOP.Calculator.Service.Command
{
    public class CalculatorCommand : ICalculatorCommand
    {
        public IEnumerable<double> ExecuteCalculator(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> LoadCalculator(string path)
        {
            throw new NotImplementedException();
        }
    }
}
