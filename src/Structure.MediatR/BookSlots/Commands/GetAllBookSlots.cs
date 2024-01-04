
using MediatR;
using Structure.Data.Dto;

namespace Structure.MediatR.Commands
{
    public class GetAllBookSlots : IRequest<List<BookSlotDto>>
    {
    }
}
