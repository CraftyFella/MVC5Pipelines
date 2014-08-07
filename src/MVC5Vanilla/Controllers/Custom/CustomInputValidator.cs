using System;
using FluentValidation;

namespace MVC5Vanilla.Controllers.Custom
{
    public class CustomInputValidator : AbstractValidator<CustomInput>
    {
        public CustomInputValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().Length(3, 400);
        }
    }
}