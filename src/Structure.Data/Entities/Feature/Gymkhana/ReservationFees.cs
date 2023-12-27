﻿using System;
namespace Structure.Data.Entities.Feature.Gymkhana
{
	public class ReservationFees
	{
		public ReservationFees()
		{
			Facility = new Facility();
		}

		public Guid? Id { get; set; }
        public Guid? FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public bool? IsAc { get; set; }
		public int? Daily { get; set; }
		public int? Monthly { get; set; }
		public int? Yearly { get; set; }
		public string? DailyDisclaimer { get; set; }
		public string? MonthlyDisclaimer { get; set; }
		public string? YearlyDisclaimer { get; set; }

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

