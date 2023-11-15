using MediatR;
using Structure.Data;
using Structure.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.MediatR.Commands
{
    public class GetAllFacilityCommand : IRequest<List<FacilityDto>>
    {
    }
}
