using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;

namespace Structure.MediatR.Handlers
{
    public class GetRecentlyRegisteredUserQueryHandler : IRequestHandler<GetRecentlyRegisteredUserQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetRecentlyRegisteredUserQueryHandler(
           IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetRecentlyRegisteredUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _userRepository.All.OrderByDescending(c => c.CreatedDate).Take(10).ToListAsync();
            return _mapper.Map<List<UserDto>>(entities);
        }
    }
}
