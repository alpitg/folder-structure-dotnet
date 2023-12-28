using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class GetGenderQueryHandler : IRequestHandler<GetGenderQuery, ServiceResponse<GenderDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetGenderQueryHandler> _logger;

        public GetGenderQueryHandler(
            IGenderRepository genderRepository,
            IMapper mapper,
            ILogger<GetGenderQueryHandler> logger)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<ServiceResponse<GenderDto>> Handle(GetGenderQuery request, CancellationToken cancellationToken)
        {
            var entity = await _genderRepository.FindAsync(request.Id);
            if (entity != null)
                return ServiceResponse<GenderDto>.ReturnResultWith200(_mapper.Map<GenderDto>(entity));
            else
            {
                _logger.LogError("Not found");
                return ServiceResponse<GenderDto>.Return404();
            }
        }
    }
}
