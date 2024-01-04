using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {
		public Guid? Id { get; set; }
		public string? FacilityName { get; set; }

    }
}
