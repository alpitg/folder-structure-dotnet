using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetTenantQuery : IRequest<ServiceResponse<TenantDto>>
    {
        public Guid Id { get; set; }
    }
}
