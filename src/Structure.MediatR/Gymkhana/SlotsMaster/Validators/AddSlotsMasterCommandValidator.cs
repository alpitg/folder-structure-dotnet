using Structure.MediatR.CommandAndQuery;
using FluentValidation;

namespace Structure.MediatR.Validators
{
    public class AddSlotsMasterCommandValidator:  AbstractValidator<AddSlotsMasterCommand>
    {
        public AddSlotsMasterCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("SlotsMaster name is required");
        }
    }
}
