namespace AbacusInstructionMachineProcessor.Core.Interfaces
{
    /// <summary>
    /// Represents a collection of processor registers for storing values
    /// Similar to CPU registers, these are fast-access storage locations
    /// </summary>
    public interface IRegisterFile
    {
        /// <summary>
        /// Gets or sets the value at the specified register index
        /// </summary>
        double this[int index] { get; set; }

        /// <summary>
        /// Gets the total number of available registers
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Resets the specified register to zero
        /// </summary>
        void Reset(int index);
    }
} 