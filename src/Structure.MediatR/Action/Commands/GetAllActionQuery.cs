using Structure.Data.Dto;
using MediatR;
using System.Collections.Generic;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllActionQuery : IRequest<ServiceResponse<List<ActionDto>>>
    {
    }
}
