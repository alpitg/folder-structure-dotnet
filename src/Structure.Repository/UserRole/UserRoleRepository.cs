using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Domain.Entities;

namespace Structure.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole, StructureDbContext>,
       IUserRoleRepository
    {
        public UserRoleRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
