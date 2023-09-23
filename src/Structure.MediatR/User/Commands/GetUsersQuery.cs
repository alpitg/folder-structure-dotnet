using MediatR;
using Structure.Data.Resources;
using Structure.Repository;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetUsersQuery : IRequest<UserList>
    {
        public UserResource UserResource { get; set; }
    }
}
