using System;
namespace Structure.Data.Dto
{
	public class ScheduledSlotsDto
    {
		public ScheduledSlotsDto()
		{
            Facility = new FacilityDto();
            ScheduledTransaction = new ScheduledTransactionDto();
        }

        public Guid? Id { get; set; }
        public Guid? TransactionId { get; set; }
        public virtual ScheduledTransactionDto? ScheduledTransaction { get; set; }

        public Guid? FacilityId { get; set; }
        public virtual FacilityDto? Facility { get; set; }

        public DateTime? ScheduledDate { get; set; }
        public byte? Start { get; set; }
        public byte? End { get; set; }

    }

}

