using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Helper;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Repository;

namespace Structure.MediatR.Handlers
{
    public class AddSlotsMasterCommandHandler : IRequestHandler<AddGenderCommand, ServiceResponse<GenderDto>>
    {
        private readonly IGenderRepository _GenderRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddSlotsMasterCommandHandler> _logger;
        
        public AddSlotsMasterCommandHandler(
           IGenderRepository GenderRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddSlotsMasterCommandHandler> logger
            )
        {
            _GenderRepository = GenderRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<GenderDto>> Handle(AddGenderCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _GenderRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Gender Already Exist");
                return ServiceResponse<GenderDto>.Return409("Gender Already Exist.");
            }

            var entity = _mapper.Map<Gender>(request);
            entity.Id = Guid.NewGuid();
            _GenderRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Gender have Error");
                return ServiceResponse<GenderDto>.Return500();
            }
            return ServiceResponse<GenderDto>.ReturnResultWith200(_mapper.Map<GenderDto>(entity));
        }
    }
}
