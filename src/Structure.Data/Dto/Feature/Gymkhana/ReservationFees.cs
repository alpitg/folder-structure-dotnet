using System;
namespace Structure.Data.Dto
{
	public class ReservationFeesDto
    {
		public ReservationFeesDto()
		{
			Facility = new FacilityDto();
		}

		public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public FacilityDto? Facility { get; set; }
        public bool? IsAc { get; set; }
		public int? Daily { get; set; }
		public string? DailyDisclaimer { get; set; }

    }
}

