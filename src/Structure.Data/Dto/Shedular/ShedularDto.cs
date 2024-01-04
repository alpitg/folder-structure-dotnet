namespace Structure.Data.Dto
{
    public class ShedularDto
    {

        public string? Date { get; set; }
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }

    public class TimeSlot : BaseEntity
    {
        public string? Slot { get; set; }
        public double? Cost { get; set; }
    }
}

