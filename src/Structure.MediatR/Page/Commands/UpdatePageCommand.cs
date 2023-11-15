using Structure.Data.Dto;
using MediatR;
using System;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdatePageCommand : IRequest<ServiceResponse<PageDto>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public int Order { get; set; }
    }
}
