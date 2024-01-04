using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Structure.MediatR.Handlers
{
    public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQuery, List<GenderDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GetAllGenderQueryHandler(
            IGenderRepository genderRepository,
            IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;

        }
        public async Task<List<GenderDto>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            var entities = await _genderRepository.All.OrderBy(c => c.Name).ToListAsync();
            return _mapper.Map<List<GenderDto>>(entities);
        }
    }
}
