﻿using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;
using Structure.Domain.Entities;

namespace Structure.MediatR.Handlers
{
    public class AddActionCommandHandler : IRequestHandler<AddActionCommand, ServiceResponse<ActionDto>>
    {
        private readonly IActionRepository _actionRepository;
        private readonly IPageRepository _tenantRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddActionCommandHandler> _logger;
        public AddActionCommandHandler(
           IActionRepository actionRepository,
           IPageRepository pageRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddActionCommandHandler> logger
            )
        {
            _actionRepository = actionRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
            _tenantRepository = pageRepository;
        }
        public async Task<ServiceResponse<ActionDto>> Handle(AddActionCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _actionRepository.FindBy(c => c.PageId == request.PageId && c.Name.Trim().ToLower() == request.Name.Trim().ToLower()).FirstOrDefaultAsync();
            if (entityExist != null)
            {
                _logger.LogError("Action already exist.");
                return ServiceResponse<ActionDto>.Return409("Action already exist.");
            }

            var page = await _tenantRepository.FindAsync(request.PageId);
            if (page == null)
            {
                _logger.LogError("Page does not exists.");
                return ServiceResponse<ActionDto>.Return404("Page does not exists.");
            }
            var entity = _mapper.Map<Domain.Entities.Action>(request);
            entity.Id = Guid.NewGuid();
            entity.Code = $"{page.Name.Replace(" ", "_")}_{entity.Name.Replace(" ", "_")}".ToUpper();
            _actionRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<ActionDto>.Return500();
            }
            var entityDto = _mapper.Map<ActionDto>(entity);
            return ServiceResponse<ActionDto>.ReturnResultWith200(entityDto);
        }
    }
}
