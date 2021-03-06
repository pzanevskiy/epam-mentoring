using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const string StringFormatExceptionMessage = "'{0}' is in wrong format.";
        private const string OverflowExceptionMessage = "Parsed value must be between {0} and {1}. Parsed value: '{2}'";

        public int Parse(string stringValue)
        {
            if (stringValue is null)
                throw new ArgumentNullException(nameof(stringValue));

            stringValue = stringValue.Trim();

            var isValid = stringValue.StartsWith('+') || stringValue.StartsWith('-')
                ? ValidateFormat(stringValue[1..])
                : ValidateFormat(stringValue);

            if (!isValid)
                throw new FormatException(string.Format(StringFormatExceptionMessage, stringValue));

            var parsedValue = stringValue[0] switch
            {
                '+' => InternalParse(stringValue[1..]),
                '-' => -1 * InternalParse(stringValue[1..]),
                _ => InternalParse(stringValue)
            };

            if (ValidateIntOverflow(parsedValue))
                throw new OverflowException(string.Format(OverflowExceptionMessage, int.MinValue, int.MaxValue, parsedValue));

            return (int)parsedValue;
        }

        private static bool ValidateFormat(string stringValue) => !string.IsNullOrWhiteSpace(stringValue) &&
                                                                  stringValue.All(c => c - '0' >= 0 && c - '0' <= 9);

        private static bool ValidateIntOverflow(long value) => value < int.MinValue || value > int.MaxValue;

        private static long InternalParse(string stringValue)
        {
            long parsedValue = 0;

            var degree = stringValue.Length - 1;

            foreach (var charValue in stringValue)
            {
                parsedValue += (charValue - '0') * (int)Math.Pow(10, degree);
                degree--;
            }

            return parsedValue;
        }
    }
}