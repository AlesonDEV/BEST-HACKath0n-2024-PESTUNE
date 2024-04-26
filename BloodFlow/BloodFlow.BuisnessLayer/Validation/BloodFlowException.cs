using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Validation
{
    public class BloodFlowException : Exception
    {
        public BloodFlowException() : base() { }

        public BloodFlowException(string message) : base(message) { }

        public BloodFlowException(string message, Exception exception) : base(message, exception) { }
    }
}
