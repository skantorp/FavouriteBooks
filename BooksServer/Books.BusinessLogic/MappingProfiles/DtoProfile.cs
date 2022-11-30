using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;

namespace Books.BusinessLogic.MappingProfiles
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Author, DictionaryDTO>();
            CreateMap<BookStatus, DictionaryDTO>();
            CreateMap<Genre, DictionaryDTO>();
            CreateMap<Note, DictionaryDTO>();
            CreateMap<IEnumerable<Author>, List<DictionaryDTO>>();
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => x.Author)));
            CreateMap<IEnumerable<Book>, List<BookDTO>>();
        }
    }
}
