using AbacusInstructionMachineProcessor.Infrastructure.Logging;
using AbacusInstructionMachineProcessor.Infrastructure;
using AbacusInstructionMachineProcessor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbacusInstructionMachineProcessor.Examples
{
    // Code for running the example Main()

    /*
    public class Program
    {
        public static void Main()
        {
            // Setup dependencies
            var loggerFactory = LoggerFactory.Create(options =>
            {
                options.MinimumLevel = LogLevel.Debug;
            });

            var logger = loggerFactory.CreateLogger<Processor>();
            var registers = new RegisterFile();
            var memory = new MemoryStack(logger);
            var security = new SecurityValidator(logger);
            var executor = new InstructionExecutor(registers, memory, logger);

            // Create processor instance
            var processor = new Processor(registers, memory, security, executor, logger);

            // Run example program
            var program = ProgramFactory.ArithmeticExample();
            var result = processor.Execute(program);
            Console.WriteLine($"Result: {result}");
        }
    }
    */
}
