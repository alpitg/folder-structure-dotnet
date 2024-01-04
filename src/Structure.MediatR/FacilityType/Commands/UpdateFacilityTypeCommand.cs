using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateFacilityTypeCommand : IRequest<ServiceResponse<FacilityTypeDto>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
