namespace MOP.PluginContracts
{
    public interface ICalculatorInputModel
    {
        public int Operation { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
    }
}
