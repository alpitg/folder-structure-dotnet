using Structure.Data.Dto;
using MediatR;
using System.Collections.Generic;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllRoleQuery : IRequest<List<RoleDto>>
    {
    }
}
