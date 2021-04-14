using Blog.Domain.DataTransferObjects;
using FluentValidation;

namespace Blog.Application.Validations.FluentValidation
{
    public class SayfaInsertUpdateValidator : AbstractValidator<SayfaInsertDto>
    {
        public SayfaInsertUpdateValidator()
        {
            RuleFor(i => i.Baslik)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(500);
        }
    }
}
