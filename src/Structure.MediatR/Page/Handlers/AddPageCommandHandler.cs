﻿using AutoMapper;
using Structure.Domain.Entities;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class AddPageCommandHandler : IRequestHandler<AddPageCommand, ServiceResponse<PageDto>>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddPageCommandHandler> _logger;
        public AddPageCommandHandler(
           IPageRepository pageRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddPageCommandHandler> logger
            )
        {
            _pageRepository = pageRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
        }
        public async Task<ServiceResponse<PageDto>> Handle(AddPageCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _pageRepository.FindBy(c => c.Name == request.Name).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Page Already Exist");
                return ServiceResponse<PageDto>.Return409("Page Already Exist.");
            }
            var existingOrder = await _pageRepository.FindBy(c => c.Order == request.Order).FirstOrDefaultAsync();
            if (existingOrder != null)
            {
                _logger.LogError("Order Number Already Exist");
                return ServiceResponse<PageDto>.Return409("Order Number Already Exist.");
            }

            var entity = _mapper.Map<Page>(request);
            entity.Id = Guid.NewGuid();
            _pageRepository.Add(entity);
            if (await _uow.SaveAsync() <= 0)
            {

                _logger.LogError("Save Page have Error");
                return ServiceResponse<PageDto>.Return500();
            }
            return ServiceResponse<PageDto>.ReturnResultWith200(_mapper.Map<PageDto>(entity));
        }
    }
}
