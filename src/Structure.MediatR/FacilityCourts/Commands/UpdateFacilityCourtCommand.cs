using MediatR;
using Structure.Data.Dto;
using Structure.Helper;


namespace Structure.MediatR.Commands
{
    public class UpdateFacilityCourtCommand : IRequest<ServiceResponse<FacilityCourtsDto>>
    {

        public Guid Id { get; set; }

        public string? CourtName { get; set; }

        public int CourtNumber { get; set; }

    }
}
