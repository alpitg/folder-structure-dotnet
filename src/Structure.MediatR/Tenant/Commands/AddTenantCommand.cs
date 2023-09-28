using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddTenantCommand : IRequest<ServiceResponse<TenantDto>>
    {
        public string? Name { get; set; }
    }
}
