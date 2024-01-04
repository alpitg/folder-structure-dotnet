using Structure.Data.Dto;
using MediatR;

namespace Structure.MediatR.CommandAndQuery
{
    public class GetAllGenderQuery : IRequest<List<GenderDto>>
    {
    }
}
