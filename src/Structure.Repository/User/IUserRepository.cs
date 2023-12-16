using Structure.Repository.GenericRepository;
using Structure.Domain.Entities;
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
