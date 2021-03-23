namespace MOP.PluginContracts
{
    /// <summary>
    /// Contract which specifies the basic expected functionality of the Calculator plugin
    /// </summary>
    /// <typeparam name="T">Return type i.e. double, int, etc</typeparam>
    public interface ICalculator<T>
    {
        double Add(double x, double y);
        double Substract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
        T Calculate(int operation, double fnumber, double snumber);
    }
}
