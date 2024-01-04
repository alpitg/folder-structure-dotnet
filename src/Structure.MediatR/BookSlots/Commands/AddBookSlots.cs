using MediatR;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.Commands
{
    public class AddBookSlots : IRequest<ServiceResponse<BookSlotDto>>
    {

        public Guid? Id { get; set; }

        public Guid? FacilityId { get; set; }

        public Facility? Facility { get; set; }

        public Guid? FacilityCourtId { get; set; }
        public FacilitiesCourts? FacilitiesCourt { get; set; }
        public List<ShedularDto>? Shedular { get; set; }

    }
}
