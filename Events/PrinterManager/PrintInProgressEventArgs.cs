using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager
{
    public class PrintInProgressEventArgs : EventArgs
    {
        public int PrintedPagesCount { get; set; }
        public int PagesCount { get; set; }
        public double Progress
        {
            get
            {
                return 100.0 * PrintedPagesCount / PagesCount;
            }
        }
    }
}
