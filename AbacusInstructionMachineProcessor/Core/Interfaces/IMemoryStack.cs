namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Represents a last-in-first-out (LIFO) stack for temporary value storage
    /// Used for procedure calls and temporary calculations
    /// </summary>
    public interface IMemoryStack
    {
        /// <summary>
        /// Pushes a value onto the top of the stack
        /// </summary>
        void Push(double value);

        /// <summary>
        /// Removes and returns the value at the top of the stack
        /// </summary>
        double Pop();
    }
} 