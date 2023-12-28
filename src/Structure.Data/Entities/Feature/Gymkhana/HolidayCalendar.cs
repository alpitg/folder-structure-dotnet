using System;
namespace Structure.Data
{
	public class HolidayCalendar : BaseEntity
    {
		public Guid? Id { get; set; }
		public DateTime? EventDate { get; set; }
		public bool? IsForAllDay { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
        public string? EventName { get; set; }

    }
}

