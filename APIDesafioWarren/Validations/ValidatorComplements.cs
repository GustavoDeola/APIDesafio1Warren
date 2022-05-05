using System.Text.RegularExpressions;

namespace APIDesafioWarren.Validations
{
    public static class ValidatorComplements
    {
        public static bool validCpf(this string cpf)
        {
            var formate = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";   

            return Regex.Match(cpf, formate).Success;
        }

        public static bool validPostalCode(this string postalcode)
        {
            var formate = "[0-9]{5}\\-?[0-9]{3}$";

            return Regex.Match(postalcode, formate).Success;
        }

        public static bool validCellphone(this string cellphone)
        {
            var formate = "[0-9]{2}?[0-9]{4}?[0-9]{4}";

            return Regex.Match(cellphone, formate).Success;
        }

    }
}
