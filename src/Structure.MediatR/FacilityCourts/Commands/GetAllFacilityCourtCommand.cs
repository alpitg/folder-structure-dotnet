using MediatR;
using Structure.Data.Dto;


namespace Structure.MediatR.Commands
{
    public class GetAllFacilityCourtCommand : IRequest<List<FacilityCourtsDto>>
    {
    }
}
