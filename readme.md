# Abacus Instruction Machine Processor (AIMP)

A lightweight virtual machine implementation that executes mathematical operations through a custom instruction set. AIMP provides an extensible platform for executing mathematical computations with register-based storage and stack-based memory management.

## 🚀 Features

- Custom instruction set for mathematical operations
- Register-based value storage
- Stack-based memory operations
- Logging
- Support for procedure calls
- Conditional branching capabilities

## 📋 Prerequisites

- .NET 8.0 or higher
- Visual Studio 2022 or Visual Studio Code

## 💻 Usage

### Basic Example

```csharp
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
var program = ProgramFactory.ArithmeticExample();
var result = processor.Execute(program);
Console.WriteLine($"Result: {result}");
```

### Creating Custom Programs

```csharp
var instructions = new[]
{
    new Instruction(OpCode.Move, 0, 42),        // Store 42 in R0
    new Instruction(OpCode.Add, 0, 8),          // Add 8 to R0
    new Instruction(OpCode.Multiply, 0, 2),     // Multiply R0 by 2
    new Instruction(OpCode.Halt, 0, 0)          // Stop execution
};

var program = new InternalProcessing(instructions);
var result = processor.Execute(program);
```

### Key Components

- `IProcessor`: Main execution interface
- `IRegisterFile`: Register storage management
- `IMemoryStack`: Stack-based memory operations
- `SecurityValidator`: Execution security enforcement
- `InstructionExecutor`: Instruction execution logic

## 🔧 Available Operations

- `Move`
- `Add`
- `Subtract`
- `Multiply`
- `Divide`
- `Exp`
- `Log`
- `Compare`
- `ConditionalJump`
- `Push`
- `Pop`
- `Call`
- `Halt`

## 🌱 Future Improvements

This project is a proof-of-concept demonstrating basic virtual machine implementation principles.
