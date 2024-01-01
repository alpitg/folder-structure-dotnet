using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeleteSlotsMasterCommand : IRequest<ServiceResponse<SlotsMasterDto>>
    {
        public Guid Id { get; set; }
    }
}
