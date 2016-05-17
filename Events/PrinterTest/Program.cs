using PrinterManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var HP = new Printer("HP LaserJet");

            HP.PrintStarted += (sender, e) => {
                Thread.Sleep(1000);
                Console.WriteLine($"{(sender as Printer)?.Name}:: Print Started"); };
            HP.PrintFinished += (sender, e) => {
                Thread.Sleep(1000);
                Console.WriteLine($"{(sender as Printer)?.Name}:: Print Finished"); };
            HP.PrintInProgress += (sender, e) => {
                Thread.Sleep(1000);
                Console.WriteLine($"{(sender as Printer)?.Name}:: Printing {e.PrintedPagesCount} of {e.PagesCount} [{e.Progress}%]");
            };

            HP.AddPapers(2);

            HP.Print(4);
        }
    }
}
