using System;
using System.Linq;

namespace Application.Validations
{
    public static class StringExtensions
    {
        public static bool ValidFullName(this string fullName)
        {
            string[] limitStrings = fullName.Split(' ');

            if (!IsValidString(fullName)) return false;

            return limitStrings.Length > 1 && limitStrings.Length < 7;
        }

        public static int ToIntAt(this string value, Index index)
        {
            var indexValue = index.IsFromEnd
                ? value.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(value, indexValue);
        }

        public static bool IsValidString(this string letter)
        {
            if (!letter.Replace(" ", string.Empty).AllCharacteresArentEqualsToTheFirstCharacter()
                || letter.Trim() != letter
                || letter.Split(' ').Contains("")
                || letter.Split(' ').Any(_ => !char.IsUpper(_.First()))
                || letter.Replace(" ", string.Empty).Any(x => !char.IsLetter(x))) return false;
                  
            return true;
        }

        public static bool IsValidNumber(this string number)
        {
            return number.All(x => char.IsDigit(x));
        }

        public static bool AllCharacteresArentEqualsToTheFirstCharacter(this string word)
        {
            return !word.All(c => c.Equals(word.First()));
        }
    }
}
