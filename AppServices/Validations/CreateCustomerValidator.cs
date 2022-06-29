using APIDesafioWarren.Models;
using App.Services;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace AppServices.Validations
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .Must(v => v.ValidFullName())
                .MaximumLength(300)
                .MinimumLength(6);

            RuleFor(c => c.Email)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(254)
                .EmailAddress(EmailValidationMode.Net4xRegex);

            RuleFor(c => c)
               .Must(c => c.EmailConfirmation == c.Email);

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(ValidCPF)
                .Length(11);

            RuleFor(c => c.Country)
                .NotEmpty()
                .MaximumLength(35)
                .MinimumLength(5);

            RuleFor(c => c.City)
                .NotEmpty()
                .MaximumLength(40)
                .MinimumLength(3);

            RuleFor(c => c.Cellphone)
               .NotEmpty()
               .WithMessage("Please complete this field")
               .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
               .MinimumLength(10)
               .WithMessage("Invalid cellphone")
               .MaximumLength(11)
               .WithMessage("Invalid cellphone");

            RuleFor(c => c.Birthdate)
                .Must(ValidBirthDate)
                .WithMessage("You must be at least 16 years old");

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
                .Length(8);

            RuleFor(c => c.Address)
             .NotEmpty()
             .WithMessage("Please complete this field");

            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("Please complete this field");
        }
        public static bool ValidEmail(Customer client)
        {
            if (client.EmailConfirmation == client.Email)
            {
                return true;
            }
            return false;
        }

        private static bool ValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (!cpf.IsValidNumber()) return false;

            if (cpf.AllCharacteresArentEqualsToTheFirstCharacter()) return false;

            var firstDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 2; i++)
            {
                firstDigitAfterDash += cpf.ToIntAt(i) * (10 - i);
            }

            firstDigitAfterDash = (firstDigitAfterDash * 10) % 11;
            firstDigitAfterDash = firstDigitAfterDash == 10 ? 0 : firstDigitAfterDash;

            var secondDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 1; i++)
            {
                secondDigitAfterDash += cpf.ToIntAt(i) * (11 - i);
            }

            secondDigitAfterDash = (secondDigitAfterDash * 10) % 11;
            secondDigitAfterDash = secondDigitAfterDash == 10 ? 0 : secondDigitAfterDash;

            return firstDigitAfterDash == cpf.ToIntAt(^2) && secondDigitAfterDash == cpf.ToIntAt(^1);
        }
        private static bool ValidBirthDate(DateTime birthdate)
        {
            var s = new DateTime(DateTime.Now.Year, birthdate.Month, birthdate.Day);
            var yearsDifference = s.Year - birthdate.Year;

            return yearsDifference >= 16;
        }
    }
}


