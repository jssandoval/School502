using System;
using backend.Core.DTOs;
using FluentValidation;

namespace backend.Infrastructure.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolDto>
    {
        public SchoolValidator()
        {
            RuleFor(school => school.Description)
                .NotNull()
                .Length(10, 1000);
            RuleFor(school => school.Name)
                .NotNull()
                .Length(10, 1000);
        }
    }
}
