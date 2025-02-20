namespace AbacusInstructionMachineProcessor.Core.Enums
{
    /// <summary>
    /// Represents the result of a comparison operation
    /// Used for conditional branching instructions
    /// </summary>
    public enum CompareState
    {
        /// <summary>
        /// Values are equal
        /// </summary>
        Equal = 0,

        /// <summary>
        /// First value is greater than second value
        /// </summary>
        Above = 1,

        /// <summary>
        /// First value is less than second value
        /// </summary>
        Below = 2
    }
} 