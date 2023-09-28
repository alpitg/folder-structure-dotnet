using FluentValidation;
using Structure.MediatR.CommandAndQuery;

namespace Structure.MediatR.Validators
{
    public class AddTenantCommandValidator : AbstractValidator<AddTenantCommand>
    {
        public AddTenantCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
