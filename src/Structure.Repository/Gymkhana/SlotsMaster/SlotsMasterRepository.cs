using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class SlotsMasterRepository : GenericRepository<ScheduledSlots, StructureDbContext>,
          ISlotsMasterRepository
    {
        public SlotsMasterRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
