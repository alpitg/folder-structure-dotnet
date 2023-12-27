using System;
namespace Structure.Data.Entities.Feature.Gymkhana
{
	public class ReservationFees
	{
		public Guid? Id { get; set; }
		public Guid? FacilityId { get; set; }
        public bool? IsAc { get; set; }
		public int? Daily { get; set; }
		public int? Monthly { get; set; }
		public int? Yearly { get; set; }
		public string? DailyDisclaimer { get; set; }
		public string? MonthlyDisclaimer { get; set; }
		public string? YearlyDisclaimer { get; set; }
    }
}

