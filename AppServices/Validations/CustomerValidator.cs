using APIDesafioWarren.Models;
using App.Services;
using Application.Models.DTOs;
using FluentValidation;
using System;

namespace APIDesafioWarren.Validations
{
    public class CustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .Must(v => v.ValidFullName())
                .MaximumLength(30)
                .MinimumLength(6);

            RuleFor(c => c.Email)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(254)
                .EmailAddress();

            RuleFor(c => c.EmailConfirmation)
               .EmailAddress();

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(v => v.ValidCpf())
                .Length(11);

            RuleFor(c => c.Country)
                .NotEmpty()
                .MaximumLength(35)
                .MinimumLength(5);

            RuleFor(c => c.City)
                .NotEmpty()
                .MaximumLength(40)
                .MinimumLength(3);
              

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .Must(v => v.ValidPostalCode())
                .Length(8);

        }

        public static bool ValidEmail(Customer client)
        {
            if (client.EmailConfirmation == client.Email)
            {
                return true;
            }
            return false;
        }
    }
}


