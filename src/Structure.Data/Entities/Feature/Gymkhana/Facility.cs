using System;
namespace Structure.Data.Entities.Feature.Gymkhana
{
	public class Facility
	{

		public Guid? Id { get; set; }
		public string? FacilityName { get; set; }

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

