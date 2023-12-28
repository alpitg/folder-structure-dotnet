using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class GenderRepository : GenericRepository<Gender, StructureDbContext>,
          IGenderRepository
    {
        public GenderRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
