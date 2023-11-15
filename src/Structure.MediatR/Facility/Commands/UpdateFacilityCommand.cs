using MediatR;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Helper;


namespace Structure.MediatR.Commands
{
    public class UpdateFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? IsHavingMultipleCourts { get; set; }

        public Guid? FacilityId { get; set; }

        public FacilityType? FacilityType { get; set; }

    }
}
