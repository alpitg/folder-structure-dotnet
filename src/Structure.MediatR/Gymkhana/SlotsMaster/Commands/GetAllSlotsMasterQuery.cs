using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllSlotsMasterQuery : IRequest<List<SlotsMasterDto>>
    {
    }
}
