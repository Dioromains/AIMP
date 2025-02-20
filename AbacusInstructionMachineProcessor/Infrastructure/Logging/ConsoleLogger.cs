using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Infrastructure.Logging
{
    /// <summary>
    /// Console implementation of ILogger
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private readonly string _category;
        private readonly LogLevel _minimumLevel;

        public ConsoleLogger(string category, LogLevel minimumLevel = LogLevel.Info)
        {
            _category = category;
            _minimumLevel = minimumLevel;
        }

        public void LogTrace(string message) => Log(LogLevel.Trace, message);
        public void LogDebug(string message) => Log(LogLevel.Debug, message);
        public void LogInfo(string message) => Log(LogLevel.Info, message);
        public void LogWarning(string message) => Log(LogLevel.Warning, message);
        public void LogError(string message, Exception? exception = null) => 
            Log(LogLevel.Error, message + (exception != null ? $"\n{exception}" : ""));

        private void Log(LogLevel level, string message)
        {
            if (level < _minimumLevel) return;

            var color = level switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Info => ConsoleColor.White,
                LogLevel.Debug => ConsoleColor.Gray,
                LogLevel.Trace => ConsoleColor.DarkGray,
                _ => ConsoleColor.White
            };

            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine($"[{level}] {_category}: {message}");
            Console.ForegroundColor = originalColor;
        }
    }
} 