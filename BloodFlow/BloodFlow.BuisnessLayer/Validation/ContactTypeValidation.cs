using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class ContactTypeValidation
    {
        private static readonly Regex phoneRegex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", RegexOptions.Compiled);

        public static void ValidateEmail(string email)
        {
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(email);

            try
            {
                var mailAddress = new MailAddress(email);
            }
            catch (FormatException)
            {
                throw new ValidationException("Email format is invalid.",
                      new FormatException("Please provide a valid email address."));
            }
        }

    }
}
