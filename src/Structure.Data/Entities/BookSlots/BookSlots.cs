

using System.ComponentModel.DataAnnotations.Schema;

namespace Structure.Data
{
    public class BookSlots : BaseEntity
    {
        public Guid? Id { get; set; }

        public Guid? FacilityId { get; set; }

        [ForeignKey("FacilityId")]
        public Facility? Facility { get; set; }

        public Guid? FacilityCourtId { get; set; }

        [ForeignKey("FacilityCourtId")]
        public FacilitiesCourts? FacilitiesCourt { get; set; }
        public string? Date { get; set; }
        public string? Slot { get; set; }
        public double? Cost { get; set; }

    }
}
