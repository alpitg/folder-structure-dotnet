﻿using Structure.Data.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetRoleUsersQuery : IRequest<List<UserRoleDto>>
    {
        public Guid RoleId { get; set; }
    }
}
