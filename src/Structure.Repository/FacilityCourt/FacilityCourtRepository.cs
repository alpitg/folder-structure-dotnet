using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;


namespace Structure.Repository
{
    public class FacilityCourtRepository : GenericRepository<FacilitiesCourts, StructureDbContext>,
        IFacilityCourtRepository
    {

        public FacilityCourtRepository(
          IUnitOfWork<StructureDbContext> uow
          ) : base(uow)
        {
        }

    }
}
