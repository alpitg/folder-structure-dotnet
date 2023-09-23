using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Domain;

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
