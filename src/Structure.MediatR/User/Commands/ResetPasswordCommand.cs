using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class ResetPasswordCommand : IRequest<ServiceResponse<UserDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
