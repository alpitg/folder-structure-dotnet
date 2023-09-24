using Structure.Data.Dto;
using MediatR;
using System;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeletePageCommand : IRequest<ServiceResponse<PageDto>>
    {
        public Guid Id { get; set; }
    }
}
