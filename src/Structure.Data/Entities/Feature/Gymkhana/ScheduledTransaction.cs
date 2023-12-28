using System;
namespace Structure.Data
{
	public class ScheduledTransaction : BaseEntity
    {
        public Guid? Id { get; set; }
        public double? TotalCost { get; set; }

    }
}

