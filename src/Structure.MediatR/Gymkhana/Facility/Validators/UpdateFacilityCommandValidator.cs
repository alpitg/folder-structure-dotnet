using Structure.MediatR.CommandAndQuery;
using FluentValidation;
using System;

namespace Structure.MediatR.Validators
{
    public class UpdateFacilityCommandValidator : AbstractValidator<UpdateFacilityCommand>
    {
        public UpdateFacilityCommandValidator()
        {
            RuleFor(c => c.Id).Must(p => p != Guid.Empty).WithMessage("Id is required");
            RuleFor(c => c.FacilityName).NotEmpty().WithMessage("Facility name is required");
        }
    }
}
