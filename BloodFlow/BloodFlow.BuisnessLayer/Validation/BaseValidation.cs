using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class BaseValidation
    {
        public static void IsWhiteSpaceOrNullOrEmpty(string inputValue)
        {
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                throw new ValidationException("Invalid input value.",
                    new ArgumentException("Input value cannot be null or only whitespace."));
            }
        }

        public static void IsObjectNull(object obj, string objectName)
        {
            if (obj == null)
            {
                throw new ValidationException($"Invalid input: {objectName} cannot be null.",
                    new ArgumentNullException(objectName));
            }
        }

    }
}
