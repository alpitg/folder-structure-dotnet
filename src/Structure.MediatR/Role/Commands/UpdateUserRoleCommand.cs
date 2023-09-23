using Structure.Data.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateUserRoleCommand : IRequest<ServiceResponse<UserRoleDto>>
    {
        public Guid Id { get; set; }
        public List<UserRoleDto> UserRoles { get; set; }
    }
}
