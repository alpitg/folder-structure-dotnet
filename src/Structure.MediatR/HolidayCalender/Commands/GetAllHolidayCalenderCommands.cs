
using MediatR;
using Structure.Data.Dto;

namespace Structure.MediatR.Commands
{
    public class GetAllHolidayCalenderCommands : IRequest<List<HolidayCalenderDto>>
    {
    }
}
