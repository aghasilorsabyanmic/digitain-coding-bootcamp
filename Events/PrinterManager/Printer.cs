using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager
{
    public class Printer
    {
        public event EventHandler PrintStarted;
        public event EventHandler PrintFinished;
        public event EventHandler<PrintInProgressEventArgs> PrintInProgress;

        public Printer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int PapersCount { get; private set; }

        public void AddPapers(int count)
        {
            PapersCount += count;
        }

        public void Print(int pagesCount)
        {
            OnPrintStarted();

            for (int i = 0; i < pagesCount; i++)
            {
                if(PapersCount == 0)
                {
                    // Fire event
                    break;
                }

                PapersCount--;
                OnPrintInProgress(i + 1, pagesCount);
            }

            OnPrintFinished();
        }

        protected virtual void OnPrintStarted()
        {
            PrintStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPrintFinished()
        {
            PrintFinished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPrintInProgress(int printedCount, int total)
        {
            var e = new PrintInProgressEventArgs
            {
                PrintedPagesCount = printedCount,
                PagesCount = total
            };

            PrintInProgress?.Invoke(this, e);
        }
    }
}
