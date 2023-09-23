using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetUserQuery : IRequest<ServiceResponse<UserDto>>
    {
        public Guid Id { get; set; }
    }
}
