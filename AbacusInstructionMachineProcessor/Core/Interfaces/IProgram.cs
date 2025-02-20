using AbacusInstructionMachineProcessor.Core.Models;

namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Represents an executable program
    /// </summary>
    public interface IProgram
    {
        IReadOnlyList<Instruction> Instructions { get; }
    }
} 