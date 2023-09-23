using Structure.Common.GenericRepository;
using Structure.Common.UnitOfWork;
using Structure.Data;
using Structure.Domain;

namespace Structure.Repository
{
    public class UserClaimRepository : GenericRepository<UserClaim, StructureDbContext>,
           IUserClaimRepository
    {
        public UserClaimRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}