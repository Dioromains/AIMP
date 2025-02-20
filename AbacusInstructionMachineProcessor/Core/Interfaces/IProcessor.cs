using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Defines the core processor operations
    /// </summary>
    public interface IProcessor
    {
        double Execute(IProgram program, bool safeMode = true);
    }
} 