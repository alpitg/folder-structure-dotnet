using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetSlotsMasterQuery : IRequest<ServiceResponse<SlotsMasterDto>>
    {
        public Guid Id { get; set; }
    }
}
