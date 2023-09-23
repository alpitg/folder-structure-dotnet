using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {
    }
}
