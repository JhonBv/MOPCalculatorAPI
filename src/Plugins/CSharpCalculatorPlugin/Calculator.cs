using MOP.PluginContracts;
using System;

namespace CSharpCalculatorPlugin
{
    public class Calculator : IPlugin, ICalculator<double>
    {
        public string Name => "CalculatorPlugin";

        public string Description => "C# Basic calculator to perform basic arithmetic operations";
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Divide(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Substract(double x, double y)
        {
            return x - y;
        }
        /// <summary>
        /// Use the operation variable to specify the operation type:
        /// 1 = Add
        /// 2 = Substract
        /// 3 = Multiply
        /// 4 = Divide
        /// </summary>
        /// <param name="operation">int</param>
        /// <param name="fnumber">First value to calculate</param>
        /// <param name="snumber">Second value to calculate</param>
        /// <returns>double: result of the operation</returns>
        public double Calculate(int operation, double fnumber, double snumber)
        {
            var result = 0.0;
            try
            {
                switch (operation)
                {
                    case 1:
                        return Add(fnumber, snumber);
                    case 2:
                        return Substract(fnumber, snumber);
                    case 3:
                        return Multiply(fnumber, snumber);
                    case 4:
                        return Divide(fnumber, snumber);
                }
            }
            catch (Exception ex)
            {
                //Change to Log with ILogger
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
