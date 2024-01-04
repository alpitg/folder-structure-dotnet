using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllFacilityTypeQuery : IRequest<List<FacilityTypeDto>>
    {
    }
}