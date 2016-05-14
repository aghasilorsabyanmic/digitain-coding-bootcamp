using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class IntegralExtensions
    {
        public static bool IsEven(this ulong n)
        {
            return n % 2 == 0;
        }
    }
}
