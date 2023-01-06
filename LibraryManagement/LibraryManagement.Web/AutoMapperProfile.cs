using AutoMapper;
using LibraryManagement.Web.DTOs.Books;
using LibraryManagement.Web.Models;

namespace LibraryManagement.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDTO>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<Book, UpdateBookDTO>();
        }

    }
}
