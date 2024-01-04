using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetFacilityTypeQuery : IRequest<ServiceResponse<FacilityTypeDto>>
    {
        public Guid Id { get; set; }
    }
}