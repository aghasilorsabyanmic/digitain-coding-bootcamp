using System;

namespace Fibonacci
{
    public class Fibonacci
    {
        public static Fibonacci Create(int length)
        {
            var sequence = new Fibonacci(length);
            sequence.Calculate();
            return sequence;
        }

        public static Fibonacci Create()
        {
            var sequence = new Fibonacci();
            sequence.Calculate();
            return sequence;
        }

        public Fibonacci(int length)
        {
            if(length < 3 || length > Capacity)
            {
                throw new ArgumentException($"The {nameof(length)} should be between 3 and {Capacity}", nameof(length));
            }

            numbers = new ulong[length];
            Length = length;
        }

        public Fibonacci() : this(Capacity)
        {

        }

        public static readonly int Capacity = 93;

        private ulong[] numbers;

        public int Length { get; private set; }

        public bool IsCalculated { get; private set; } = default(bool);

        public ulong this[int index]
        {
            get
            {
                if (!IsCalculated)
                {
                    throw new NotCalculatedException("Not Calculated the sequence.", "Hello World!");
                    //throw new InvalidOperationException("Not Calculated.");
                }

                ThrowIfWrongIndex(index);

                return numbers[index];
            }

            private set
            {
                ThrowIfWrongIndex(index);

                numbers[index] = value;
            }
        }

        private void ThrowIfWrongIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException($"Index should belong to (0, {Length}]");
            }
        }

        public void Calculate()
        {
            IsCalculated = true;

            this[0] = 1;
            this[1] = 1;
            this[2] = 2;

            for (int i = 3; i < Length; i++)
            {
                checked
                {
                    this[i] = this[i - 1] + this[i - 2];
                }
            }
        }
    }
}
