using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNCFDI.Exceptions
{
    public sealed class EmptyEmployeeDataException : Exception
    {
        public EmptyEmployeeDataException()
        {
        }

        public EmptyEmployeeDataException(string message)
            : base(message)
        {
        }

        public EmptyEmployeeDataException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
