using System.Security;
using AbacusInstructionMachineProcessor.Core.Interfaces;
using AbacusInstructionMachineProcessor.Core.Models;

namespace AbacusInstructionMachineProcessor.Services
{
    /// <summary>
    /// Handles security validation
    /// </summary>
    public class SecurityValidator
    {
        private readonly ILogger _logger;

        public SecurityValidator(ILogger logger)
        {
            _logger = logger;
        }

        public void ValidateInstruction(Instruction instruction, int registerCount)
        {
            if (instruction.DestinationIndex >= registerCount)
            {
                _logger.LogWarning($"Invalid register access: {instruction.DestinationIndex}");
                throw new SecurityException($"Invalid register index: {instruction.DestinationIndex}");
            }

            if ((byte)instruction.Operation > 11)
            {
                _logger.LogWarning($"Invalid operation: {instruction.Operation}");
                throw new SecurityException($"Invalid operation code: {instruction.Operation}");
            }
        }
    }
} 