using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeleteFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {
        public Guid Id { get; set; }
    }
}
