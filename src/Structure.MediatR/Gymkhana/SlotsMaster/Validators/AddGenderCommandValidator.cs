using Structure.MediatR.CommandAndQuery;
using FluentValidation;

namespace Structure.MediatR.Validators
{
    public class AddGenderCommandValidator:  AbstractValidator<AddGenderCommand>
    {
        public AddGenderCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Gender name is required");
        }
    }
}
