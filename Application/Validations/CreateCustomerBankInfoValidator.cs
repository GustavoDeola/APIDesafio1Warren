using Application.Models.Requests;
using FluentValidation;

namespace Application.Validations
{
    public class CreateCustomerBankInfoValidator : AbstractValidator<CreateCustomerBankInfoRequest>
    {
        public CreateCustomerBankInfoValidator()
        {
            RuleFor(c => c.AccountBalance)
                .NotEmpty();
        }
    }
}

