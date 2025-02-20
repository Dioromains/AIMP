using System.Diagnostics;
using AbacusInstructionMachineProcessor.Core.Enums;
using AbacusInstructionMachineProcessor.Core.Interfaces;
using AbacusInstructionMachineProcessor.Services;

namespace AbacusInstructionMachineProcessor
{
    /// <summary>
    /// Main implementation of the Abacus Instruction Machine Processor
    /// </summary>
    public class Processor : IProcessor
    {
        private readonly IRegisterFile _registers;
        private readonly IMemoryStack _memory;
        private readonly SecurityValidator _security;
        private readonly InstructionExecutor _executor;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the processor
        /// </summary>
        public Processor(
            IRegisterFile registers,
            IMemoryStack memory,
            SecurityValidator security,
            InstructionExecutor executor,
            ILogger logger)
        {
            _registers = registers ?? throw new ArgumentNullException(nameof(registers));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _security = security ?? throw new ArgumentNullException(nameof(security));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Executes the provided program and returns the result from register 0
        /// </summary>
        /// <param name="program">The program to execute</param>
        /// <param name="safeMode">Whether to run with security checks enabled</param>
        /// <returns>The final value in register 0</returns>
        public double Execute(IProgram program, bool safeMode = true)
        {
            if (program == null) throw new ArgumentNullException(nameof(program));

            _logger.LogInfo("Starting program execution");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                ExecuteInstructions(program, safeMode);

                var executionTime = stopwatch.ElapsedMilliseconds;
                _logger.LogInfo($"Program completed in {executionTime}ms");

                return _registers[0];
            }
            catch (Exception ex)
            {
                _logger.LogError("Program execution failed", ex);
                throw new ProcessorException("Program execution failed", ex);
            }
        }

        private void ExecuteInstructions(IProgram program, bool safeMode)
        {
            int instructionPointer = 0;
            var instructions = program.Instructions;

            while (instructionPointer < instructions.Count)
            {
                var instruction = instructions[instructionPointer];

                if (instruction.Operation == OpCode.Halt)
                {
                    _logger.LogDebug("Halt instruction encountered");
                    break;
                }

                if (safeMode)
                {
                    _security.ValidateInstruction(instruction, _registers.Count);
                }

                try
                {
                    _executor.Execute(instruction, ref instructionPointer);
                    instructionPointer++;
                }
                catch (Exception ex)
                {
                    throw new ProcessorException(
                        $"Error executing instruction at position {instructionPointer}", ex);
                }
            }
        }
    }

    /// <summary>
    /// Custom exception for processor-related errors
    /// </summary>
    public class ProcessorException : Exception
    {
        public ProcessorException(string message) : base(message) { }
        public ProcessorException(string message, Exception inner) : base(message, inner) { }
    }
}