using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{


    class Program
    {


        static void Main(string[] args)
        {
            //var lis = new MyList<string>();
            //lis.Add("hello world!");
            //lis.Add("hello world!");
            //lis.Add("hello world!");
            //lis.Add("hello world!");
            //lis.Add("hello world!");
            //lis.Add("hello world!");
            //lis.Add("hello world!");




            //foreach(var n in inst1)
            //{
            //    Console.WriteLine(n);
            //}

            //Console.WriteLine(lis.Count);
            //Console.WriteLine(lis.Capacity);

            //Console.ReadKey();


            Action<int> f1 = (int i) => Console.WriteLine(i);
            Action<double> f2 = (double i) => Console.WriteLine(i);



        }

        static public void myFunc(IEnumerable coll)
        {
            foreach(var element in coll)
            {
                Console.WriteLine(element);
            }
        }

    }
}
