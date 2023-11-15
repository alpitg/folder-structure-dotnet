using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Data
{
    public class FacilitiesCalender : BaseEntity
    {

        public Guid? Id { get; set; }

        public string? Year { get; set; }

        public DateTime HolidayDate { get; set; }

        public string? WeeklyOffDays { get; set;}

    }
}
