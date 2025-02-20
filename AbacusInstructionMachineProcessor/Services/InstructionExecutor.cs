using AbacusInstructionMachineProcessor.Core.Enums;
using AbacusInstructionMachineProcessor.Core.Interfaces;
using AbacusInstructionMachineProcessor.Core.Models;

namespace AbacusInstructionMachineProcessor.Services
{
    /// <summary>
    /// Handles instruction execution logic
    /// </summary>
    public class InstructionExecutor
    {
        private readonly IRegisterFile _registers;
        private readonly IMemoryStack _memory;
        private CompareState _compareState;
        private readonly ILogger _logger;

        public InstructionExecutor(
            IRegisterFile registers,
            IMemoryStack memory,
            ILogger logger)
        {
            _registers = registers;
            _memory = memory;
            _logger = logger;
        }

        public void Execute(Instruction instruction, ref int ip)
        {
            _logger.LogDebug($"Executing {instruction}");

            switch (instruction.Operation)
            {
                case OpCode.Move:
                    _registers[instruction.DestinationIndex] = instruction.SourceValue;
                    break;

                case OpCode.Add:
                    _registers[instruction.DestinationIndex] += instruction.SourceValue;
                    break;

                case OpCode.Subtract:
                    _registers[instruction.DestinationIndex] -= instruction.SourceValue;
                    break;

                case OpCode.Multiply:
                    _registers[instruction.DestinationIndex] *= instruction.SourceValue;
                    break;

                case OpCode.Divide:
                    if (instruction.SourceValue == 0)
                        throw new DivideByZeroException("Cannot divide by zero");
                    _registers[instruction.DestinationIndex] /= instruction.SourceValue;
                    break;

                case OpCode.Exp:
                    _registers[instruction.DestinationIndex] = Math.Exp(instruction.SourceValue);
                    break;

                case OpCode.Log:
                    if (instruction.SourceValue <= 0)
                        throw new ArgumentException("Cannot take log of non-positive number");
                    _registers[instruction.DestinationIndex] = Math.Log(instruction.SourceValue);
                    break;

                case OpCode.Compare:
                    var value = _registers[instruction.DestinationIndex];
                    _compareState = value < instruction.SourceValue ? CompareState.Below :
                                  value > instruction.SourceValue ? CompareState.Above :
                                                                  CompareState.Equal;
                    break;

                case OpCode.ConditionalJump:
                    if (((CompareState)instruction.SourceValue & _compareState) == _compareState)
                    {
                        ip += (int)_registers[instruction.DestinationIndex];
                    }
                    break;

                case OpCode.Push:
                    _memory.Push(instruction.SourceValue);
                    break;

                case OpCode.Pop:
                    _registers[instruction.DestinationIndex] = _memory.Pop();
                    break;

                case OpCode.Halt:
                    break;

                default:
                    throw new InvalidOperationException($"Unknown operation: {instruction.Operation}");
            }
        }
    }
}