using System;
namespace Structure.Data
{
	public class ReservationFees : BaseEntity
    {
		public ReservationFees()
		{
			Facility = new Facility();
		}

		public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public bool? IsAc { get; set; }
		public int? Daily { get; set; }
		public string? DailyDisclaimer { get; set; }

    }
}

