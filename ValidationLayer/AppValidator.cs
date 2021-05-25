using System;

namespace ValidationLayer
{
    public class AppValidator
    {
        // Validate string length
        public static bool ValidateString(string text, int min, int max)
        {
            return text.Length > min && text.Length < max;
        }

        // Validate that value is numeric and fall into a range
        public static bool ValidateNumber(dynamic number, double min, double max)
        {
            bool isNumeric = double.TryParse(number.ToString(), out double num);
            if (!isNumeric)
                return false;
            return (num >= min && num <= max);
        }

        // Validate that date in the past
        public static bool ValidateDateNotAfter(DateTime date, DateTime past, bool mustBeBeforeNow = false)
        {
            if (mustBeBeforeNow)
                return date < past && date < DateTime.Now;
            return date < past;
        }
    }
}
