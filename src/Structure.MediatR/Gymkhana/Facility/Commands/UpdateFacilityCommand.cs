using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {
		public Guid? Id { get; set; }
		public string? FacilityName { get; set; }
    }
}
