using IronPython.Hosting;
using MOP.PluginContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonCalculatorPlugin
{
    public class Calculator : IPlugin, ICalculator<double>
    {
        public string Name => "Calculator";

        public string Description => "Python basic calculator invoked from within a C# library";

        /// <summary>
        /// Python Calculator does not use all the methods from the ICalculator<T> contract. The reason is that the different methods are within the Python Script.
        /// To perform a calculation pass the Operation Type:
        /// 1 = Add
        /// 2 = Substract
        /// 3 = Multiply
        /// 4 = Divide
        /// </summary>
        /// <param name="operation">int</param>
        /// <param name="fnumber">double: First number to perform the calculation</param>
        /// <param name="snumber">double: second number to perform the calculation</param>
        /// <returns>double: result of the operation</returns>
        public double Calculate(int operation, double fnumber, double snumber)
        {
            var result = 0.0;
            try
            {
                int i1 = operation;
                char op = (char)(i1 + '0');
                var engine = Python.CreateEngine();
                dynamic py = engine.ExecuteFile(@"Plugins\PythonCalculatorPlugin\MOP.Calculator.Python.py");
                //Instantiate the Python Calculator
                dynamic calc = py.Calculator(op, fnumber, snumber);
                //Perform calculation (passing params)
                var performcalc = calc.doCalculate(op, fnumber, snumber);
                result = performcalc;

            }
            catch (Exception ex)
            {
                //Change to Log with ILogger
                Console.Write(ex.Message);
            }

            return result;
        }
        public double Add(double x, double y)
        {
            throw new NotImplementedException();
        }
        public double Divide(double x, double y)
        {
            throw new NotImplementedException();
        }

        public double Multiply(double x, double y)
        {
            throw new NotImplementedException();
        }

        public double Substract(double x, double y)
        {
            throw new NotImplementedException();
        }
    }
}
