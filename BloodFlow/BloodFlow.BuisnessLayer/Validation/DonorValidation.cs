using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Validation
{
    public static class DonorValidation
    {
        public static void ValidateDonor(DonorModel donor)
        {
            BaseValidation.IsObjectNull(donor, nameof(donor));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(donor.Name);
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(donor.Surname);
            //ValidateBirthDate(donor.DateOfBirthday);
            //ValidatePhotoLink(donor.PhotoLink);
        }

        private static void ValidateBirthDate(DateTime birthDate)
        {
            var minDate = new DateTime(1900, 1, 1);
            var maxDate = DateTime.UtcNow;

            if (birthDate < minDate || birthDate > maxDate)
            {
                throw new ValidationException($"Invalid birth date: {birthDate}. Must be between 1900 and now.");
            }
        }

        private static void ValidatePhotoLink(string photoLink)
        {
            if (string.IsNullOrWhiteSpace(photoLink) || !Uri.IsWellFormedUriString(photoLink, UriKind.Absolute))
            {
                throw new ValidationException("Invalid input value.",
                      new UriFormatException("Invalid photo URL."));
            }

            if (!Regex.IsMatch(photoLink, @"^https?://", RegexOptions.IgnoreCase))
            {
                throw new ValidationException("Invalid input value.",
                      new UriFormatException("Invalid photo URL: URL must start with http or https."));
            }
        }

    }
}
