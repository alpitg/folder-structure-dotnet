using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddHolidayCalendarCommand : IRequest<ServiceResponse<HolidayCalendarDto>>
    {
		public Guid? Id { get; set; }
		public DateTime? EventDate { get; set; }
		public bool? IsForAllDay { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
        public string? EventName { get; set; }

    }
}
