using Application.Models.Requests;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace Application.Validations
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
                .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
                .MaximumLength(35)
                .MinimumLength(5);

            RuleFor(c => c.City)
                .NotEmpty()
                .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
                .MaximumLength(40)
                .MinimumLength(3);

            RuleFor(c => c.Cellphone)
               .NotEmpty()
               .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
               .MinimumLength(10)
               .MaximumLength(11);
               
            RuleFor(c => c.Birthdate)
                .Must(ValidBirthDate)
                .WithMessage("You must be at least 16 years old");

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .Must(v => v.IsValidNumber())
                .MinimumLength(8)
                .MaximumLength(9);

            RuleFor(c => c.Address)
             .NotEmpty()
             .Must(v => v.IsValidString())
             .MinimumLength(2)
             .MaximumLength(100);

            RuleFor(c => c.Number)
                .NotEmpty()
                .GreaterThan(0);
        }

        private static bool ValidCPF(string cpf)
        {
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (!cpf.IsValidNumber()) return false;

            if (!cpf.AllCharacteresArentEqualsToTheFirstCharacter()) return false;

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
            var today = DateTime.Now;

            int age = today.Year - birthdate.Year;

            if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
                age--;

            return age > 16;
        }
    }
}