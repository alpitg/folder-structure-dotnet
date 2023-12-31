﻿using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddFacilityTypeCommand : IRequest<ServiceResponse<FacilityTypeDto>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

    }
}
