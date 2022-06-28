﻿using Application.Models.DTOs;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace AppServices.Validations
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
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

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter())
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
                .Must(v => v.AllCharacteresArentEqualsToTheFirstCharacter());

            RuleFor(c => c.Address)
             .NotEmpty()
             .WithMessage("Please complete this field");

            RuleFor(c => c.Number)
                .NotEmpty()
                .WithMessage("Please complete this field");
        }
        private static bool ValidBirthDate(DateTime birthdate)
        {
            var s = new DateTime(DateTime.Now.Year, birthdate.Month, birthdate.Day);
            var yearsDifference = s.Year - birthdate.Year;

            return yearsDifference >= 16;
        }
    }
}