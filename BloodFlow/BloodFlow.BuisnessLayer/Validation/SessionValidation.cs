using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class SessionValidation
    {
        public static void ValidateSession(SessionModel session)
        {
            BaseValidation.IsObjectNull(session, nameof(session));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(session.DonorCenterName);
            ValidateBloodVolume(session.BloodVolume);
            //ValidateDate(session.Date);
        }

        private static void ValidateBloodVolume(int bloodVolume)
        {
            if (bloodVolume > 4)
            {
                throw new ValidationException("It is not allowed for a person to donate more than 4 litres.");
            }
        }

        private static void ValidateDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ValidationException("Invalid input value.",
                      new InvalidDataException("Date cannot be in the future."));
            }
        }
    }
}
