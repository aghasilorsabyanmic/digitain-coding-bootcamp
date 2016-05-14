using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sequence = Fibonacci.Create();

                for (int i = 0; i < sequence.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {sequence[i]}");
                }

                var evenValues = sequence.GetEvens();

                foreach (var item in evenValues)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                var t = sequence[sequence.Length];

                
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"{exception.ParamName} => {exception.Message}");
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (NotCalculatedException exception)
            {
                Console.WriteLine($"{exception.Message} === {exception.MyProperty}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.Read();
        }
    }
}
