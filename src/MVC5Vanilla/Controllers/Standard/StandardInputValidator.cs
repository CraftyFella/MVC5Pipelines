using System;
using FluentValidation;

namespace MVC5Vanilla.Controllers.Standard
{
    public class StandardInputValidator : AbstractValidator<StandardInput>
    {
        public StandardInputValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().Length(3, 400);
        }
    }
}