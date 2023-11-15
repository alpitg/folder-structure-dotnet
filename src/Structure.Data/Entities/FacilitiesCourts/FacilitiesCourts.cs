using System.ComponentModel.DataAnnotations.Schema;

namespace Structure.Data
{
    public class FacilitiesCourts : BaseEntity
    {
        public Guid? Id { get; set; }

        public string? CourtName { get; set; }

        public int CourtNumber { get; set; }

        public Guid? FacilitiesId { get; set; }

        [ForeignKey("FacilitiesId")]
        public Facility? Facilities { get; set; }

        public float CourtFees { get; set; }

    }
}
