using Structure.MediatR.CommandAndQuery;
using FluentValidation;
using System;

namespace Structure.MediatR.Validators
{
    public class UpdateGenderCommandValidator : AbstractValidator<UpdateGenderCommand>
    {
        public UpdateGenderCommandValidator()
        {
            RuleFor(c => c.Id).Must(p => p != Guid.Empty).WithMessage("Id is required");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Gender name is required");
        }
    }
}
