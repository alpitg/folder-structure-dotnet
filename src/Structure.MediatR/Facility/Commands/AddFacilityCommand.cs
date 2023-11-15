using MediatR;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.MediatR.Commands
{
    public class AddFacilityCommand : IRequest<ServiceResponse<FacilityDto>>
    {

        public Guid? Id { get; set; }

        public string? Name { get; set; }
        public bool? IsHavingMultipleCourts { get; set; }

        public Guid? FacilityId { get; set; }
        
        public FacilityType? FacilityType { get; set;}


    }
}
