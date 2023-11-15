using MediatR;
using Structure.Data.Dto;

namespace Structure.MediatR.Commands
{
    public class GetAllFacilityTypeQuery : IRequest<List<FacilityTypeDto>>
    {
    }
}
