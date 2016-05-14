using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate void MyDelegate();
        public delegate double YourDelegate(double value);
        public delegate string AnotherDelegate();

        static void Main(string[] args)
        {
            var d1 = new MyDelegate(F1);
            MyDelegate d2 = F2;
            MyDelegate d3 = null;
            d3 += d2;
            d3 += d1;
            d3 += d2;
            d3 -= d2;
            d3 += d1 + d2;

            Function(d1);
            Function(d2);
            Function(d3);

            YourDelegate d4 = Math.Sin;

            var obj = new object();

            AnotherDelegate d5 = obj.ToString;

            Action a1 = F1;
            Action<string> a2 = Console.WriteLine;
            Action<int[]> a3 = Array.Sort;

            Func<double, double, double> f1 = Math.Pow;

            Action t1 = delegate () { };
            Action<string> t2 = delegate (string s) { Console.WriteLine(s); };

            t2("Hello");

            Action l1 = () => { };
            //Action<string> l2 = (s) => { Console.WriteLine(s); };
            Action<string> l2 = s => Console.WriteLine(s);

            Func<string> l3 = () => string.Empty;
            Func<int, int, long> l4 = (x, y) => 
            {
                var result = x + y;
                return result;
            };

            var tuple = F();
            Console.WriteLine(tuple.Item1);
        }

        static void F1()
        {
            Console.WriteLine("F1");
        }

        static void F2()
        {
            Console.WriteLine("F2");
        }

        static Tuple<int, string, float, object, Action> F()
        {
            return Tuple.Create(5, "", 2f, new object(), new Action(F1));
        }

        static void Function(MyDelegate d)
        {
            if(d == null)
            {
                throw new ArgumentNullException(nameof(d));
            }

            d();
        }
    }
}
