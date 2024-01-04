using Structure.Data;
using Structure.Domain;
using Structure.Repository.GenericRepository;
using Structure.Repository.UnitOfWork;

namespace Structure.Repository
{
    public class HolidayCalendarRepository : GenericRepository<HolidayCalendar, StructureDbContext>,
          IHolidayCalendarRepository
    {
        public HolidayCalendarRepository(
            IUnitOfWork<StructureDbContext> uow
            ) : base(uow)
        {
        }
    }
}
