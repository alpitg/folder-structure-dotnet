using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;

namespace Structure.MediatR.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserList>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserList> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers(request.UserResource);
        }
    }
}
