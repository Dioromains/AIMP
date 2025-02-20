using AbacusInstructionMachineProcessor.Core.Enums;

namespace AbacusInstructionMachineProcessor.Core.Models
{
    /// <summary>
    /// Represents a single VM instruction
    /// </summary>
    public record Instruction(OpCode Operation, byte DestinationIndex, double SourceValue)
    {
        public override string ToString() => 
            $"{Operation} R{DestinationIndex}, {SourceValue}";
    }
} 