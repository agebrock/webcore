using System.Text.RegularExpressions;

namespace jarowa
{
    public class PhoneNumber : IPhoneNumber
    {
      
      
        public string Validate(string phoneNumber, string internationalPrefix) {
            phoneNumber = this.RemoveWhitespaces(phoneNumber);
            string? prefix;
            string? includedInternationalPrefix = this.GetCountryCode(phoneNumber);
            // optional feature: if the user sets the countrycode we try to use it here
            if (includedInternationalPrefix != null)
            {
                prefix = includedInternationalPrefix;
            }
            else
            {
                prefix = internationalPrefix;
            }

            string localNumber = GetLocalNumber(phoneNumber);

            string mappedNumber = prefix + localNumber;

            if (mappedNumber.Length < 10)
            {
                throw new Exception("PHONE_NUMBER_INVALID_LENGTH");
            }

            return mappedNumber;
        }

        public string RemoveWhitespaces(string phoneNumber)
        {
            return phoneNumber.Replace(" ", "");
        }


        public string? GetCountryCode(string phoneNumber)
        {
            // try to extract the country code
            Match match = Regex.Match(phoneNumber, @"^\+\d{2}");
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return null;
            }
        }

        public string CleanLocalNumber(string localNumber)
        {
           return Regex.Replace(localNumber, "[^0-9]", "");
        }

        public string GetLocalNumber(string phoneNumber)
        {
            string localPrefix = "0";
            string? code = this.GetCountryCode(phoneNumber);
            string localNumber;
            if (code != null)
            {
                localNumber = phoneNumber.Replace(code,"");
            }
            else
            {
                localNumber = phoneNumber;
            }
            localNumber = CleanLocalNumber(localNumber);

            if (localNumber.StartsWith(localPrefix))
            {
                // using some fancy Csharp magic instead of string.substring
                localNumber = localNumber[1..];
            }
            return localNumber;
        }


    }
}
