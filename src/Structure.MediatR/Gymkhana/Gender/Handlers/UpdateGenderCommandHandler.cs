using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, ServiceResponse<GenderDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGenderCommandHandler> _logger;

        public UpdateGenderCommandHandler(
           IGenderRepository genderRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateGenderCommandHandler> logger
            )
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<GenderDto>> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _genderRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Gender Name Already Exist.");
                return ServiceResponse<GenderDto>.Return409("Gender Name Already Exist.");
            }
            entityExist = await _genderRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;
            entityExist.DisplayName = request.DisplayName;
            
            _genderRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<GenderDto>.Return500();
            }
            return ServiceResponse<GenderDto>.ReturnResultWith200(_mapper.Map<GenderDto>(entityExist));
        }
    }
}
