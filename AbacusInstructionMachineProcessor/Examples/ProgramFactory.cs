using AbacusInstructionMachineProcessor.Core.Enums;
using AbacusInstructionMachineProcessor.Core.Interfaces;
using AbacusInstructionMachineProcessor.Core.Models;

namespace AbacusInstructionMachineProcessor.Examples
{
    /// <summary>
    /// Creates example for demonstration
    /// </summary>
    public static class ProgramFactory
    {
        /// <summary>
        /// Creates a simple arithmetic program that:
        /// 1. Loads 42 into register 0
        /// 2. Adds 8 to it (result: 50)
        /// 3. Multiplies by 2 (result: 100)
        /// 4. Halts execution
        /// </summary>
        public static IProgram ArithmeticExample()
        {
            return new InternalProcessing(new[]
            {
                new Instruction(OpCode.Move, 0, 42),        // Store value 42 in register 0 (R0 = 42)
                new Instruction(OpCode.Add, 0, 8),          // Add 8 to value in register 0 (R0 = R0 + 8)
                new Instruction(OpCode.Multiply, 0, 2),     // Multiply register 0 by 2 (R0 = R0 * 2)
                new Instruction(OpCode.Halt, 0, 0)          // Stop program execution
            });
        }

        /// <summary>
        /// Creates a loop that:
        /// 1. Initializes a counter in R1
        /// 2. Counts from 0 to 10
        /// 3. Uses conditional jumps for flow control
        /// </summary>
        public static IProgram LoopExample()
        {
            return new InternalProcessing(new[]
            {
                new Instruction(OpCode.Move, 1, 0),                                         // Initialize counter in register 1 (R1 = 0)
                new Instruction(OpCode.Compare, 1, 10),                                     // Compare R1 with value 10
                new Instruction(OpCode.ConditionalJump, 0, (double)CompareState.Equal),     // If R1 equals 10, jump to halt instruction
                new Instruction(OpCode.Add, 1, 1),                                          // Increment counter (R1 = R1 + 1)
                new Instruction(OpCode.Move, 0, -3),                                        // Prepare jump back 3 instructions
                new Instruction(OpCode.ConditionalJump, 0, 1),                              // Jump back to compare instruction
                new Instruction(OpCode.Halt, 0, 0)                                          // Stop program execution
            });
        }
    }
}