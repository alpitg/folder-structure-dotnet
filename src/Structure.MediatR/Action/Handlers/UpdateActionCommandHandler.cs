﻿using AutoMapper;
using Structure.Data.Dto;
using Structure.Domain.Entities;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class UpdateActionCommandHandler : IRequestHandler<UpdateActionCommand, ServiceResponse<ActionDto>>
    {
        private readonly IActionRepository _actionRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateActionCommandHandler> _logger;
        public UpdateActionCommandHandler(
           IActionRepository actionRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<UpdateActionCommandHandler> logger
            )
        {
            _actionRepository = actionRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<ActionDto>> Handle(UpdateActionCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _actionRepository.FindBy(c => c.Name == request.Name && c.Id != request.Id && c.PageId == request.PageId)
                .FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Action Name Already Exist.");
                return ServiceResponse<ActionDto>.Return409("Action Name Already Exist.");
            }
            entityExist = await _actionRepository.FindBy(v => v.Id == request.Id).FirstOrDefaultAsync();
            entityExist.Name = request.Name;
            entityExist.Order = request.Order;
            _actionRepository.Update(entityExist);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<ActionDto>.Return500();
            }
            var entityDto = _mapper.Map<ActionDto>(entityExist);
            return ServiceResponse<ActionDto>.ReturnSuccess();
        }
    }
}
