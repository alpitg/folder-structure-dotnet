using MediatR;
using Structure.Data.Dto;
using Structure.Helper;


namespace Structure.MediatR.Commands
{
    public class DeleteFacilityCourtCommand : IRequest<ServiceResponse<FacilityCourtsDto>>
    {

        public Guid Id { get; set; }

    }
}
