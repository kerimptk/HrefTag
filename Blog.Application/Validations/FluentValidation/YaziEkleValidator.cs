using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Validations.FluentValidation
{
    public class YaziEkleValidator : AbstractValidator<YaziDto>
    {
        public YaziEkleValidator()
        {


        }
    }
    public class YaziGuncelleValidator : AbstractValidator<YaziUpdateDto>
    {
        public YaziGuncelleValidator()
        {
            RuleFor(i => i.Baslik)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(500);

            RuleFor(i => i.SelectedCategoryIds)
                .NotNull();
        }
    }
}
