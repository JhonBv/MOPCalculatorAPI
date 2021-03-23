using MOP.PluginContracts;

namespace MOP.Calculator.Models
{
    public class CalculatorInputModel : ICalculatorInputModel
    {
        public int Operation { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
    }
}
