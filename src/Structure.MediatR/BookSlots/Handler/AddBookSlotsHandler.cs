using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;
using Structure.Repository.UnitOfWork;
using System.Collections.Generic;

namespace Structure.MediatR.Handler
{
    public class AddBookSlotsHandler : IRequestHandler<AddBookSlots, ServiceResponse<BookSlotDto>>
    {

        private readonly IBookSlotsRepository _bookSlotsRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddBookSlotsHandler> _logger;

        public AddBookSlotsHandler(
            IBookSlotsRepository bookSlotsRepository,
            IUnitOfWork<StructureDbContext> uow,
            IMapper mapper,
            ILogger<AddBookSlotsHandler> logger)
        {
            _bookSlotsRepository = bookSlotsRepository;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<BookSlotDto>> Handle(AddBookSlots request, CancellationToken cancellationToken)
        {
            var existingEntity = await _bookSlotsRepository.FindBy(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (existingEntity != null && request != null)
            {
                var data = new List<BookSlots>();

                if (request.Shedular != null)
                {
                    foreach (var item in request.Shedular)
                    {
                        var bookItem = new BookSlots();
                        foreach (var slotItem in item.TimeSlots)
                        {
                            bookItem = new BookSlots()
                            {
                                Id = Guid.NewGuid(),
                                Facility = request.Facility,
                                FacilityId = request.FacilityId,
                                FacilitiesCourt = request.FacilitiesCourt,
                                FacilityCourtId = request.FacilityCourtId,
                                Date = item.Date,
                                Slot = slotItem.Slot,
                                Cost = slotItem.Cost,
                            };
                        }
                        data.Add(bookItem);
                    }

                }

                // TODO: data is now your plane list , insert into the db now
                //}

                _bookSlotsRepository.AddRange(data);
                if (await _uow.SaveAsync() <= 0)
                {
                    _logger.LogError("Save Have error");
                    return ServiceResponse<BookSlotDto>.Return500();
                }
                return ServiceResponse<BookSlotDto>.ReturnResultWith200(_mapper.Map<BookSlotDto>(data));

            }

            return ServiceResponse<BookSlotDto>.ReturnResultWith204();
          

        }
    }
}
