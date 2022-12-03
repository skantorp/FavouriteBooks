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
			CreateMap<Book, BookDTO>();
		}
	}
}
