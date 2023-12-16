using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;
using Structure.Domain.Entities;
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