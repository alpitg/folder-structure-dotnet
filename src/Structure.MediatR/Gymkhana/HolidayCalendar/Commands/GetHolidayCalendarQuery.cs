using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetHolidayCalendarQuery : IRequest<ServiceResponse<HolidayCalendarDto>>
    {
        public Guid Id { get; set; }
    }
}
