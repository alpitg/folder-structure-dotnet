using Structure.MediatR.CommandAndQuery;
using FluentValidation;

namespace Structure.MediatR.Validators
{
    public class AddFacilityCommandValidator:  AbstractValidator<AddFacilityCommand>
    {
        public AddFacilityCommandValidator()
        {
            RuleFor(c => c.FacilityName).NotEmpty().WithMessage("Facility name is required");
        }
    }
}
