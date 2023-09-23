using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UserLoginCommand : IRequest<ServiceResponse<UserAuthDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RemoteIp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
