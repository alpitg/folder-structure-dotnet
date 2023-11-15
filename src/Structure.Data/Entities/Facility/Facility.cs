using System.ComponentModel.DataAnnotations.Schema;

namespace Structure.Data
{
    public class Facility : BaseEntity
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public bool? IsHavingMultipleCourts { get; set; }

        public Guid? FacilityTypeId { get; set; }

        [ForeignKey("FacilityTypeId")]
        public FacilityType? FacilityType { get; set; }

    }
}
