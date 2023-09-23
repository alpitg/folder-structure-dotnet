﻿using Structure.Data.Dto;
using MediatR;
using System;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetRoleQuery: IRequest<ServiceResponse<RoleDto>>
    {
        public Guid Id { get; set; }
    }
}
