using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace APIDesafioWarren.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .MaximumLength(30)
                .WithMessage("Full name surpasses the limit off characters")
                .WithMessage("Insert your full name")
                .MinimumLength(6)
                .WithMessage("Full name must have more than 6 characters");

            RuleFor(c => c.Email)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Insert a valid email!")
                .MaximumLength(254)
                .WithMessage("Insert a valid email!")
                .EmailAddress();
                
            RuleFor(c => c.EmailConfirmation)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .EmailAddress();

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.ValidCpf())
                .WithMessage("Invalid CPF")
                .Length(14)
                .WithMessage("CPF must have to contain 14 characters");

            RuleFor(c => c.Cellphone)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.ValidCellphone())
                .Length(11)
                .WithMessage("Invalid cellphone");

            RuleFor(c => c.Birthdate)
                .Must(v => ValidAges(v))
                .WithMessage("You must be at least 16 years old");          

            RuleFor(c => c.Country)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .MaximumLength(35)
                .WithMessage("The country surpass the limit length")
                .MinimumLength(5)
                .WithMessage("The country name is too short");

            RuleFor(c => c.City)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .MaximumLength(40)
                .WithMessage("The City informed surpasses the limit off characters")
                .MinimumLength(3)
                .WithMessage("The City informed is too short, please enter at least 3 characters");

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.ValidPostalCode())
                .Length(9)
                .WithMessage("Invalid postal code");

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
        private static bool ValidAges (DateTime birthdate)
        {
             var s = new DateTime(DateTime.Now.Year, birthdate.Month, birthdate.Day);

             var yearsDifference = s.Year - birthdate.Year;

                return yearsDifference >= 16;
        }    
    }
}


