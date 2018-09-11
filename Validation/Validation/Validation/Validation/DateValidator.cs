using System;
using System.Text.RegularExpressions;

namespace Validation.Validation
{
    public class DateValidator : IValidationRule<string>
    {
        const string pattern = @"[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{4}$";

        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            bool isMatch = regex.IsMatch(value);
            if (!isMatch) return false;
            string[] date = value.Split('.');
            int day = Convert.ToInt32(date[0]);
            int mounth = Convert.ToInt32(date[1]);
            if (day == 0 || mounth == 0)
                return false;
            if (day > 31 || mounth > 12)
                return false;
            return true;
        }
    }
}
