using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllTenantQuery : IRequest<List<TenantDto>>
    {
    }
}
