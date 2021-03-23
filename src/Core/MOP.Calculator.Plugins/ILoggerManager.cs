namespace MOP.PluginContracts
{
    /// <summary>
    /// Basic Logging functionality for implementing clients
    /// </summary>
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
