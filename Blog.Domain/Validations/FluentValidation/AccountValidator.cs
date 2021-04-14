using Blog.Domain.DataTransferObjects;
using FluentValidation;

namespace Blog.Domain.Validations.FluentValidation
{
    public class AccountValidator : AbstractValidator<ProfilDto>
    {
        public AccountValidator()
        {

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(i => i.Surname)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);
        }
    }
}
