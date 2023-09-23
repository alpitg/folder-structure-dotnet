using MediatR;
using Structure.Data.Dto;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetRecentlyRegisteredUserQuery : IRequest<List<UserDto>>
    {
    }
}
