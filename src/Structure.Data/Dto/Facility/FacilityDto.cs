
namespace Structure.Data.Dto
{
    public class FacilityDto
    {

        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public bool? IsHavingMultipleCourts { get; set; }

        public Guid? FacilityId { get; set; }

        public FacilityType? FacilityType { get; set;}

    }
}
