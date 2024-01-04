using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository;
using MediatR;
using Structure.Helper;
using Structure.Repository.UnitOfWork;

namespace Structure.MediatR.Handlers
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, ServiceResponse<GenderDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;

        public DeleteGenderCommandHandler(
           IGenderRepository GenderRepository,
            IUnitOfWork<StructureDbContext> uow
            )
        {
            _genderRepository = GenderRepository;
            _uow = uow;
        }

        public async Task<ServiceResponse<GenderDto>> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var entityExist = await _genderRepository.FindAsync(request.Id);
            if (entityExist == null)
            {
                return ServiceResponse<GenderDto>.Return404();
            }
            _genderRepository.Delete(request.Id);
            if (await _uow.SaveAsync() <= 0)
            {
                return ServiceResponse<GenderDto>.Return500();
            }
            return ServiceResponse<GenderDto>.ReturnSuccess();
        }
    }
}
