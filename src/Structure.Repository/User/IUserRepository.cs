using Structure.Common.GenericRepository;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Data.Resources;

namespace Structure.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserList> GetUsers(UserResource userResource);
        Task<UserAuthDto> BuildUserAuthObject(User appUser);
    }
}
