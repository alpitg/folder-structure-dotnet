using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllFacilityQuery : IRequest<List<FacilityDto>>
    {
    }
}
