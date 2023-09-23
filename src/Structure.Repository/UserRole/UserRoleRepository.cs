using Structure.Common.GenericRepository;
using Structure.Common.UnitOfWork;
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
