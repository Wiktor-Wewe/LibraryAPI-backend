using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;

namespace LibraryAPI
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<Book, BooksDto>();

            CreateMap<Author, AuthorsDto>();

            CreateMap<AddAuthorDto, Author>();

            CreateMap<AddBookDto, Book>();

            CreateMap<Author, AuthorDto>();
        }
    }
}
