using Structure.MediatR.CommandAndQuery;
using FluentValidation;
using System;

namespace Structure.MediatR.Validators
{
    public class UpdateSlotsMasterCommandValidator : AbstractValidator<UpdateSlotsMasterCommand>
    {
        public UpdateSlotsMasterCommandValidator()
        {
            RuleFor(c => c.Id).Must(p => p != Guid.Empty).WithMessage("Id is required");
            RuleFor(c => c.Name).NotEmpty().WithMessage("SlotsMaster name is required");
        }
    }
}
