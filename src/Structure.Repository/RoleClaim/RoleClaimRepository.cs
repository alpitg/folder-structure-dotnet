using Structure.Common.GenericRepository;
using Structure.Common.UnitOfWork;
using Structure.Data;
using Structure.Domain;

namespace Structure.Repository
{
    public class RoleClaimRepository : GenericRepository<RoleClaim, StructureDbContext>,
           IRoleClaimRepository
    {
        public RoleClaimRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}