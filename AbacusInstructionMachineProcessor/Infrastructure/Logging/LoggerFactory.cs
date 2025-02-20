using AbacusInstructionMachineProcessor.Core.Interfaces;
using AbacusInstructionMachineProcessor.Infrastructure.Logging;

namespace AbacusInstructionMachineProcessor.Infrastructure.Logging
{
    /// <summary>
    /// Factory for creating logger instances
    /// </summary>
    public class LoggerFactory
    {
        private readonly LogLevel _minimumLevel;

        public LoggerFactory(LogLevel minimumLevel = LogLevel.Info)
        {
            _minimumLevel = minimumLevel;
        }

        /// <summary>
        /// Creates a logger for the specified category
        /// </summary>
        public ILogger CreateLogger<T>() =>
            new ConsoleLogger(typeof(T).Name, _minimumLevel);

        /// <summary>
        /// Creates a logger with the specified category name
        /// </summary>
        public ILogger CreateLogger(string category) =>
            new ConsoleLogger(category, _minimumLevel);

        /// <summary>
        /// Creates a configured logger factory
        /// </summary>
        public static LoggerFactory Create(Action<LoggerFactoryOptions> configure)
        {
            var options = new LoggerFactoryOptions();
            configure(options);
            return new LoggerFactory(options.MinimumLevel);
        }
    }

    /// <summary>
    /// Configuration options for the logger factory
    /// </summary>
    public class LoggerFactoryOptions
    {
        public LogLevel MinimumLevel { get; set; } = LogLevel.Info;
    }
}