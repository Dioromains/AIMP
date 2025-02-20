using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Core.Models
{
    /// <summary>
    /// Standard program implementation
    /// </summary>
    public class InternalProcessing : IProgram
    {
        private readonly List<Instruction> _instructions;

        public InternalProcessing(IEnumerable<Instruction> instructions)
        {
            _instructions = instructions.ToList();
        }

        public IReadOnlyList<Instruction> Instructions => _instructions;
    }
} 