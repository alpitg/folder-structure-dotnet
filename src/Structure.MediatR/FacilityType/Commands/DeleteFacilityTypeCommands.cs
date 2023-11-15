using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeleteFacilityTypeCommands : IRequest<ServiceResponse<FacilityTypeDto>>
    {

        public Guid Id { get; set; }

    }
}
