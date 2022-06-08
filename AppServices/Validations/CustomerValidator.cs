using APIDesafioWarren.Models;
using Application.Models.DTOs;
using FluentValidation;
using System;

namespace APIDesafioWarren.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerResponse>
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
                .WithMessage("Please complete this field")
                .MinimumLength(6)
                .WithMessage("Insert a valid email!")
                .MaximumLength(254)
                .WithMessage("Insert a valid email!")
                .EmailAddress();
                
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("Please complete this field")
                .Must(v => v.ValidCpf())
                .WithMessage("Invalid CPF")
                .Length(14)
                .WithMessage("CPF must have to contain 14 characters");
   

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

        }
    }
}


