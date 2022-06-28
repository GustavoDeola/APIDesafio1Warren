using System.Linq;

namespace AppServices.Validations
{
    public static class StringExtensions
    {
        public static bool ValidFullName(this string fullName)
        {
            string[] validSpaces = fullName.Trim().Split(' ');
            string copyFullName = fullName;
            fullName = fullName.Trim();

            if (AllCharacteresArentEqualsToTheFirstCharacter(fullName)
                && fullName != copyFullName
                && fullName.All(v => v.Equals(fullName.First(z => char.IsUpper(z))))
                )
            {
                fullName.Replace(" ", "");
                return fullName.All(x => char.IsLetter(x) && validSpaces.Length > 1);
            }

            return false;
        }

        public static bool IsValidString(this string letter)
        {

            if (!AllCharacteresArentEqualsToTheFirstCharacter(letter)
                || letter.Trim() != letter
                || letter.Split(' ').Contains("")
                || letter.Split(' ').Any(_ => !char.IsUpper(_.First()))
                || letter.Replace(" ", string.Empty).Any(x => !char.IsLetter(x))) return false;

            return true;
        }

        public static bool AllCharacteresArentEqualsToTheFirstCharacter(this string word)
        {
            return !word.All(c => c.Equals(word.First()));
        }
    }
}
