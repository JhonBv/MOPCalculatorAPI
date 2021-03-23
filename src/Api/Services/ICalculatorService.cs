using MOP.Calculator.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MOP.Calculator.API.Services
{
    /// <summary>
    /// Calculator Service contract
    /// </summary>
    public interface ICalculatorService
    {
        double ExecuteCalculator(string path, CalculatorInputModel input);
        double LoadCalculator(Assembly assembly, CalculatorInputModel input);
    }
}
