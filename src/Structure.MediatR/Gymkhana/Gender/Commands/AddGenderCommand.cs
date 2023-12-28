using MediatR;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class AddGenderCommand : IRequest<ServiceResponse<GenderDto>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }

    }
}
