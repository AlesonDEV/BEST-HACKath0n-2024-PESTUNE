using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException() : base() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception exception) : base(message, exception) { }
    }

    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message) : base(message) { }
    }
}
