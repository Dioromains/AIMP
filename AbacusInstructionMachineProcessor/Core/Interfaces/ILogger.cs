namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Defines logging operations for the processor
    /// </summary>
    public interface ILogger
    {
        void LogTrace(string message);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception? exception = null);
    }
} 