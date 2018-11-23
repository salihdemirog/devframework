using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException()
        {

        }

        public SecurityException(string message) : base(message)
        {

        }

        public SecurityException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
