using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Defines the core virtual machine operations
    /// </summary>
    public interface IVirtualMachine
    {
        double Execute(IProgram program, bool safeMode = true);
    }
} 