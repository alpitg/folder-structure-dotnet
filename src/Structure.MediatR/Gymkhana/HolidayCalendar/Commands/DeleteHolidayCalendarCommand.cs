using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeleteHolidayCalendarCommand : IRequest<ServiceResponse<HolidayCalendarDto>>
    {
        public Guid Id { get; set; }
    }
}
