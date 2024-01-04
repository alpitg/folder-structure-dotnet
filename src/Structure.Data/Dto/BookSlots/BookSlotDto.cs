
namespace Structure.Data.Dto
{
    public class BookSlotDto
    {

        public Guid? Id { get; set; }

        public Guid? FacilityId { get; set; }

        public Facility? Facility { get; set; }

        public Guid? FacilityCourtId { get; set; }
        public FacilitiesCourts? FacilitiesCourts { get; set; }
        public ShedularDto? Shedular { get; set; }
        

    }
}
