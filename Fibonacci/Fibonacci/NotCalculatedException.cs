using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class NotCalculatedException : Exception
    {
        public string MyProperty { get; set; } = string.Empty;

        public NotCalculatedException() 
            : base()
        {
        }

        public NotCalculatedException(string message) 
            : base(message)
        {
        }

        public NotCalculatedException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public NotCalculatedException(string message, string myProperty)
            : base(message)
        {
            MyProperty = myProperty;
        }
    }
}
