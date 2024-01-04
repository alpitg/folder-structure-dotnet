using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Helper;
using Structure.MediatR.Commands;
using Structure.Repository;


namespace Structure.MediatR.Handler
{
    public class GetAllHolidayCalenderHandler : IRequestHandler<GetAllHolidayCalenderCommands, List<HolidayCalenderDto>>
    {

        private readonly IHolidayCalenderRepository _holidayCalenderRepository;
        private readonly IMapper _mapper;

        public GetAllHolidayCalenderHandler(
            IHolidayCalenderRepository holidayCalenderRepository,
            IMapper mapper)
        {
            _holidayCalenderRepository = holidayCalenderRepository;
            _mapper = mapper;
        }

        public async Task<List<HolidayCalenderDto>> Handle(GetAllHolidayCalenderCommands request, CancellationToken cancellationToken)
        {

            try
            {

                var entities = await _holidayCalenderRepository.All.OrderBy(c => c.EventName).ToListAsync();
                return _mapper.Map<List<HolidayCalenderDto>>(entities);

            }
            catch (Exception ex)
            {
                throw;
            }


            //var result = new List<HolidayCalenderDto>();

            //foreach (var entity in entities)
            //{
            //    var dto = new HolidayCalenderDto
            //    {
            //        Id = entity.Id.GetValueOrDefault(),
            //        EventDate = entity.EventDate,
            //        IsForAllDay = entity.IsForAllDay,
            //        StartTime = entity.StartTime,
            //        EndTime = entity.EndTime,
            //        EventName = entity.EventName,
            //    };

            //    result.Add(dto);
            //}

            //return _mapper.Map<List<HolidayCalenderDto>>(result);

        }


    }
}
