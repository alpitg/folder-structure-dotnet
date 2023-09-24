using Structure.Data.Dto;
using MediatR;
using System.Collections.Generic;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllPageQuery : IRequest<List<PageDto>>
    {
    }
}
