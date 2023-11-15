using MediatR;
using Structure.Data.Dto;
using Structure.Helper;


namespace Structure.MediatR.Commands
{
    public class DeleteFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {
        public Guid Id { get; set; }

    }
}
