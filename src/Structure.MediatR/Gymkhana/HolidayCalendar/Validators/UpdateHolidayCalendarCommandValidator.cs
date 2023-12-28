using Structure.MediatR.CommandAndQuery;
using FluentValidation;
using System;

namespace Structure.MediatR.Validators
{
    public class UpdateHolidayCalendarCommandValidator : AbstractValidator<UpdateHolidayCalendarCommand>
    {
        public UpdateHolidayCalendarCommandValidator()
        {
            RuleFor(c => c.Id).Must(p => p != Guid.Empty).WithMessage("Id is required");
            RuleFor(c => c.EventName).NotEmpty().WithMessage("HolidayCalendar name is required");
            RuleFor(c => c.EventDate).NotEmpty().WithMessage("HolidayCalendar date is required");
        }
    }
}
