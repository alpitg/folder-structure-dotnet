using System;
namespace Structure.Data.Entities.Feature.Gymkhana
{
	public class Timings
    {
        public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public byte? Start { get; set; }
        public byte? End { get; set; }
        public bool? IsWeeekend { get; set; }
        public string? Gender { get; set; }
    }
}

