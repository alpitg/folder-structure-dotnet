using Structure.Data.Dto;
using MediatR;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class DeleteGenderCommand : IRequest<ServiceResponse<GenderDto>>
    {
        public Guid Id { get; set; }
    }
}
