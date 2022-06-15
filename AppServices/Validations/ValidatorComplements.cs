using System.Linq;
using System.Text.RegularExpressions;

namespace APIDesafioWarren.Validations
{
    public static class ValidatorComplements
    {
        public static bool ValidFullName(this string fullName)
        {
            if (fullName.All(c => c.Equals(fullName.First()))) return false;

            else if (fullName.Trim() != fullName) return false;

            else if (fullName.All(x => char.IsLetter(x)))

                
                return true;
            string[] validSpaces = fullName.Split(' ');

            string[] separateNames = fullName[1];

            return false;


        }
       
        public static bool ValidCpf(this string cpf)
        {
            if (cpf.All(c => c.Equals(cpf.First()))) return false;
            return true;
        }

        public static bool ValidPostalCode(this string postalcode)
        {
            if (postalcode.All(c => c.Equals(postalcode.First()))) return false;
            return true;
        }

        public static bool ValidCellphone(this string cellphone)
        {
            if (cellphone.All(c => c.Equals(cellphone.First()))) return false;
            return true;
        }
    }
}
