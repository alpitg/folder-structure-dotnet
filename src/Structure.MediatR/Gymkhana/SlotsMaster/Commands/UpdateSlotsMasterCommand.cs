using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateSlotsMasterCommand : IRequest<ServiceResponse<SlotsMasterDto>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
    }
}
