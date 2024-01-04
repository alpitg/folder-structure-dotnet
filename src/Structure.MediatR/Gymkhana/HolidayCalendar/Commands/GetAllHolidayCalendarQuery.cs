using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllHolidayCalendarQuery : IRequest<List<HolidayCalendarDto>>
    {
    }
}
