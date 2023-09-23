using Structure.Data.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateRoleCommand: IRequest<ServiceResponse<RoleDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<RoleClaimDto> RoleClaims { get; set; }
    }
}
