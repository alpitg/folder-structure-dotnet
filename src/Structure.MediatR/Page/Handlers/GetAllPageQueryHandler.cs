using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Structure.MediatR.Handlers
{
    public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQuery, List<PageDto>>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IMapper _mapper;

        public GetAllPageQueryHandler(
            IPageRepository pageRepository,
            IMapper mapper)
        {
            _pageRepository = pageRepository;
            _mapper = mapper;

        }
        public async Task<List<PageDto>> Handle(GetAllPageQuery request, CancellationToken cancellationToken)
        {
            var entities = await _pageRepository.All.OrderBy(c => c.Order).ToListAsync();
            return _mapper.Map<List<PageDto>>(entities);
        }
    }
}
