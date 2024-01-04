using System;
namespace Structure.Data
{
	public class ScheduledSlots : BaseEntity
    {
		public ScheduledSlots()
		{
            Facility = new Facility();
            ScheduledTransaction = new ScheduledTransaction();
        }

        public Guid? Id { get; set; }
        public Guid? TransactionId { get; set; }
        public virtual ScheduledTransaction? ScheduledTransaction { get; set; }

        public Guid? FacilityId { get; set; }
        public virtual Facility? Facility { get; set; }

        public DateTime? ScheduledDate { get; set; }
        public byte? Start { get; set; }
        public byte? End { get; set; }

    }

}

