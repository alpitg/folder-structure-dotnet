using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.Commands;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
    public class GetAllBookSlotsHandler : IRequestHandler<GetAllBookSlots, List<BookSlotDto>>
    {

        private readonly IBookSlotsRepository _bookSlotsRepository;
        private readonly IMapper _mapper;

        public GetAllBookSlotsHandler(
            IBookSlotsRepository bookSlotsRepository, IMapper mapper)
        {
            _bookSlotsRepository = bookSlotsRepository;
            _mapper = mapper;
        }

        public async Task<List<BookSlotDto>> Handle(GetAllBookSlots request, CancellationToken cancellationToken)
        {
            var entities = await _bookSlotsRepository.All.OrderBy(c => c.Id).ToListAsync();

            var entitiesGroup = entities
                .GroupBy(c => new
                {
                    c.FacilityCourtId,
                    c.FacilitiesCourt,
                    c.Facility,
                    c.FacilityId,
                    c.Date
                })
                .Select(gcs => new BookSlotDto()
                {
                    FacilityCourtId = gcs.Key.FacilityCourtId,
                    FacilitiesCourts = gcs.Key.FacilitiesCourt,
                    Facility = gcs.Key.Facility,
                    FacilityId = gcs.Key.FacilityId,
                    //Date = gcs.Key.Date,
                    Shedular = new ShedularDto()
                    {
                        Date = gcs.ToList().FirstOrDefault().Date,
                        TimeSlots = gcs.Select(x => new TimeSlot { Slot = x.Slot, Cost = x.Cost }).ToList()
                    },
                });

            //List<BookSlotDto> list = new List<BookSlotDto>();
            //foreach (var entity in entitiesGroup)
            //{
            //    list.Add(new BookSlotDto
            //    {
                   
                   
            //    });
            //}

            //return _mapper.Map<List<BookSlotDto>>(entities);
            return _mapper.Map<List<BookSlotDto>>(entitiesGroup.ToList());
        }
    }
}
