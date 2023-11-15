using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class FacilityRepository : GenericRepository<Facility, StructureDbContext>,
        IFacilityRepository
    {

        public FacilityRepository(
           IUnitOfWork<StructureDbContext> uow
           ) : base(uow)
        {
        }

    }
}
