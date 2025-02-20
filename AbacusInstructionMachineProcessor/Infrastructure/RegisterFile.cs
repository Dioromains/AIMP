using AbacusInstructionMachineProcessor.Core.Interfaces;

namespace AbacusInstructionMachineProcessor.Infrastructure
{
    /// <summary>
    /// Manages register storage
    /// </summary>
    public class RegisterFile : IRegisterFile
    {
        private readonly double[] _registers;

        public RegisterFile(int registerCount = 4)
        {
            _registers = new double[registerCount];
        }

        public double this[int index]
        {
            get => _registers[index];
            set => _registers[index] = value;
        }

        public int Count => _registers.Length;

        public void Reset(int index) => _registers[index] = 0;
    }
} 