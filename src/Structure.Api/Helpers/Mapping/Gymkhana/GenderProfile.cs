using AutoMapper;
using Structure.Data.Dto;
using Structure.Data;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<AddGenderCommand, Gender>();
            CreateMap<UpdateGenderCommand, Gender>();
        }
    }
}
