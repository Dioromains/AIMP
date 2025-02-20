using System.Diagnostics;
using AbacusInstructionMachineProcessor;
using AbacusInstructionMachineProcessor.Examples;
using AbacusInstructionMachineProcessor.Infrastructure;
using AbacusInstructionMachineProcessor.Infrastructure.Logging;
using AbacusInstructionMachineProcessor.Services;

namespace AIMP.CLI
{
    internal class Program
    {
        public static void Main()
        {
            // Setup
            var loggerFactory = LoggerFactory.Create(options =>
            {
                options.MinimumLevel = LogLevel.Debug;
            });

            var logger = loggerFactory.CreateLogger<Processor>();
            var registers = new RegisterFile();
            var memory = new MemoryStack(logger);
            var security = new SecurityValidator(logger);
            var executor = new InstructionExecutor(registers, memory, logger);

            // Create instance
            var processor = new Processor(registers, memory, security, executor, logger);

            // Run example 1
            Console.WriteLine("");
            Console.WriteLine("=== Arithmetic Example ===");
            Console.WriteLine("");
            var program1 = ProgramFactory.ArithmeticExample();
            var result1 = processor.Execute(program1);
            Console.WriteLine($"Result: {result1}");

            // Run example 2
            Console.WriteLine("");
            Console.WriteLine("=== Loop Example ===");
            Console.WriteLine("");
            var program2 = ProgramFactory.LoopExample();
            var result2 = processor.Execute(program2);
            Console.WriteLine($"Result: {result2}");

            Console.ReadKey();
        }
    }
}
