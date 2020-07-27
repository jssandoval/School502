using FluentValidation;
using school.Core.DTOs;

namespace school.Infrastructure.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolDto>
    {
        public SchoolValidator()
        {
            RuleFor(school => school.Description)
                .NotNull()
                .Length(10, 1000)
                .WithMessage("long is between 10 and 1000");
            RuleFor(school => school.Name)
                .NotNull()
                .Length(10, 1000);
        }
    }
}
