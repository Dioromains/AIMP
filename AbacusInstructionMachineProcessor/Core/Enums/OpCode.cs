namespace AbacusInstructionMachineProcessor.Core.Enums
{
    /// <summary>
    /// Available operation codes
    /// </summary>
    public enum OpCode : byte
    {
        Move = 0,
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4,
        Exp = 5,
        Log = 6,
        Compare = 7,
        ConditionalJump = 8,
        Push = 9,
        Pop = 10,
        Call = 11,
        Halt = 255
    }
} 