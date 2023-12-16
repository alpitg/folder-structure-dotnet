using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;
using Structure.Domain.Entities;

namespace Structure.MediatR.Handlers
{
    public class DeletePageCommandHandler : IRequestHandler<DeletePageCommand, ServiceResponse<PageDto>>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        public DeletePageCommandHandler(
           IPageRepository pageRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _pageRepository = pageRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<PageDto>> Handle(DeletePageCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _pageRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<PageDto>.Return404();
            }
            _pageRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<PageDto>.Return500();
            }
            return ServiceResponse<PageDto>.ReturnSuccess();
        }
    }
}
