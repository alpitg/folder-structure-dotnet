using AutoMapper;
using Structure.Data;
using Structure.MediatR.Commands;

namespace Structure.Api.Helpers.Mapping
{
    public class BookSlotsProfile : Profile
    {
        public BookSlotsProfile() { 
            CreateMap<BookSlots,  BookSlotsProfile>().ReverseMap();
            CreateMap<AddBookSlots, BookSlots>();
            CreateMap<GetAllBookSlots, BookSlots>();

        }
    }
}
