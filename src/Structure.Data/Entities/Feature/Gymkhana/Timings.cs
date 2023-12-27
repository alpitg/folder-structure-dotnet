using System;
namespace Structure.Data.Entities.Feature.Gymkhana
{
	public class Timings
    {
        public Timings()
        {
            Facility = new Facility();
            Gender = new Gender();
        }

        public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public virtual Facility? Facility { get; set; }
        public byte? Start { get; set; }
        public byte? End { get; set; }
        public bool? IsWeeekend { get; set; }
        public Guid? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }

        private DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }
        public Guid ModifiedBy { get; set; }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

