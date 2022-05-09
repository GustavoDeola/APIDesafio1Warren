using APIDesafioWarren.DataBase;
using APIDesafioWarren.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace APIDesafioWarren.Validations
{
    public class ClientValidator : AbstractValidator<ClientRegister>

    {
        public ClientValidator()
        {
            RuleFor(c => c.fullName)
             .NotEmpty()
             .MaximumLength(30)
             .WithMessage("Full name surpasses the limit off characters")
             .WithMessage("Insert your full name")
            .MinimumLength(6)
            .WithMessage("Full name must have more than 6 characters");

            RuleFor(c => c.email)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Insert a valid email!")
                .MaximumLength(254)
                .WithMessage("Insert a valid email!")
                .EmailAddress();
                

            RuleFor(c => c.emailConfirmation)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .EmailAddress();


            RuleFor(c => c.cpf)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.validCpf())
                .WithMessage("Invalid CPF")
                .Length(14)
                .WithMessage("CPF must have to contain 14 characters");

            RuleFor(c => c.cellphone)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.validCellphone())
                .Length(11)
                .WithMessage("Invalid cellphone");

            RuleFor(c => c.birthdate)
                .LessThan(DateTime.Parse("01/01/2006"))
                .WithMessage("You must be at least 16 years old");          

            RuleFor(c => c.country)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .MaximumLength(35)
                .WithMessage("The country surpass the limit length")
                .MinimumLength(5)
                .WithMessage("The country name is too short");

            RuleFor(c => c.city)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .MinimumLength(3)
                .WithMessage("The city name is too short please enter at least 3 characters")
                .MaximumLength(40)
                .WithMessage("The City informed surpasses the limit off characters");

            RuleFor(c => c.postalCode)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.validPostalCode())
                .Length(9)
                .WithMessage("Invalid postal code");

            RuleFor(c => c.address)
                .NotEmpty()
                .WithMessage("Please complete this field");

            RuleFor(c => c.number)
                .NotEmpty()
                .WithMessage("Please complete this field");
        }
        public static bool validEmail(ClientRegister client)
        {
            if (client.emailConfirmation == client.email)
            {
                return true;
            }
                return false;
        }


    }
}


