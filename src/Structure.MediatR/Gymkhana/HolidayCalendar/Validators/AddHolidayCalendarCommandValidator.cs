using Structure.MediatR.CommandAndQuery;
using FluentValidation;

namespace Structure.MediatR.Validators
{
    public class AddHolidayCalendarCommandValidator:  AbstractValidator<AddHolidayCalendarCommand>
    {
        public AddHolidayCalendarCommandValidator()
        {
            RuleFor(c => c.EventName).NotEmpty().WithMessage("HolidayCalendar name is required");
            RuleFor(c => c.EventDate).NotEmpty().WithMessage("HolidayCalendar date is required");
        }
    }
}
