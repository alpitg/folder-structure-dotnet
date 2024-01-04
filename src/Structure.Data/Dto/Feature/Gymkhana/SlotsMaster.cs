using System;
namespace Structure.Data.Dto
{
	public class SlotsMasterDto
    {
		public SlotsMasterDto()
		{
			TimeSlots = new TimeSlotsDto();
			ReservationFees = new ReservationFeesDto();
		}

		public TimeSlotsDto? TimeSlots { get; set; }
		public ReservationFeesDto? ReservationFees { get; set; }

    }
}

