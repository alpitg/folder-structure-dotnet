using System;
namespace Structure.Data.Dto
{
	public class TimeSlotsDto
    {
        public TimeSlotsDto()
        {
            Facility = new FacilityDto();
            Gender = new GenderDto();
        }

        public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public virtual FacilityDto? Facility { get; set; }
        public byte? StartTime { get; set; }
        public byte? EndTime { get; set; }
        public bool? IsWeekend { get; set; }
        public Guid? GenderId { get; set; }
        public virtual GenderDto? Gender { get; set; }

    }
}

