using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class FibonacciExtension
    {
        public static Dictionary<int, ulong> GetEvens(this Fibonacci sequence)
        {
            var result = new Dictionary<int, ulong>();
            for (int i = 0; i < sequence.Length; i++)
            {
                if(sequence[i].IsEven())
                {
                    //result.Add(i, sequence[i]);
                    result[i] = sequence[i];
                }
            }

            return result;
        }
    }
}
