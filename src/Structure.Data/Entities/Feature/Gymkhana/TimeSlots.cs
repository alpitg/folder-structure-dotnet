using System;
namespace Structure.Data
{
	public class TimeSlots : BaseEntity
    {
        public TimeSlots()
        {
            Facility = new Facility();
            Gender = new Gender();
        }

        public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public virtual Facility? Facility { get; set; }
        public byte? StartTime { get; set; }
        public byte? EndTime { get; set; }
        public bool? IsWeekend { get; set; }
        public Guid? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }

    }
}

