using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Infrastructure
{
    /// <summary>
    /// Manages the execution stack
    /// </summary>
    public class MemoryStack : IMemoryStack
    {
        private readonly Stack<double> _stack = new();
        private readonly ILogger _logger;

        public MemoryStack(ILogger logger)
        {
            _logger = logger;
        }

        public void Push(double value)
        {
            _stack.Push(value);
            _logger.LogTrace($"Pushed value: {value}");
        }

        public double Pop()
        {
            var value = _stack.Pop();
            _logger.LogTrace($"Popped value: {value}");
            return value;
        }
    }
} 