using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddFacilityCourtsCommands : IRequest<ServiceResponse<FacilityCourtsDto>>
    {

        public Guid? Id { get; set; }

        public string? CourtName { get;  set; }
        public float CourtFees { get; set; }

        public float CourtNumber { get; set; }
    }
}
