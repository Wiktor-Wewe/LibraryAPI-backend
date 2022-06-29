using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public interface ILibraryService
    {
        AuthorDto GetAuthorById(int id);
        BookDto GetBookById(int id);
        IEnumerable<AuthorsDto> GetAllAuthors();
        IEnumerable<BooksDto> GetAllBooks();
        int AddAuthor(AddAuthorDto dto);
        int AddBook(int id, AddBookDto dto);
        bool DeleteBook(int id);
        bool DeleteAuthor(int id);
        bool UpdateAuthor(int id, UpdateAuthorDto dto);
        bool UpdateBook(int id, UpdateBookDto dto);
    }

    public class LibraryService : ILibraryService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;

        public LibraryService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool UpdateBook(int id, UpdateBookDto dto)
        {
            var book = _dbContext
                .Book
                .FirstOrDefault(b => b.Id == id);

            if (book is null) return false;

            book.Title = dto.Title;
            book.Description = dto.Description;
            book.ReleaseDate = dto.ReleaseDate;

            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateAuthor(int id, UpdateAuthorDto dto)
        {
            var author = _dbContext
                .Author
                .FirstOrDefault(b => b.Id == id);

            if (author is null) return false;

            author.FirstName = dto.FirstName;
            author.Surname = dto.Surname;

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = _dbContext
                .Book
                .FirstOrDefault(b => b.Id == id);

            if (book is null) return false;

            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _dbContext
                .Author
                .FirstOrDefault(b => b.Id == id);

            if (author is null) return false;

            _dbContext.Author.Remove(author);
            _dbContext.SaveChanges();
            return true;
        }

        public AuthorDto GetAuthorById(int id)
        {
            var autor = _dbContext
                .Author
                .FirstOrDefault(b => b.Id == id);

            if (autor is null) return null;

            var authorDto = _mapper.Map<AuthorDto>(autor);
            return authorDto;
        }

        public BookDto GetBookById(int id)
        {
            var book = _dbContext
                .Book
                .FirstOrDefault(b => b.Id == id);

            if (book is null) return null;

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public IEnumerable<AuthorsDto> GetAllAuthors()
        {
            var authors = _dbContext
                .Author
                .ToList();

            var authorsDto = _mapper.Map<List<AuthorsDto>>(authors);
            return authorsDto;
        }

        public IEnumerable<BooksDto> GetAllBooks()
        {
            var books = _dbContext
                .Book
                .ToList();

            var booksDtos = _mapper.Map<List<BooksDto>>(books);
            return booksDtos;
        }

        public int AddAuthor(AddAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            _dbContext.Author.Add(author);
            _dbContext.SaveChanges();
            return author.Id;
        }

        public int AddBook(int id, AddBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            var author = _dbContext.Author.FirstOrDefault(i => i.Id == id);

            var authors = new List<Author>();
            authors.Add(author);
            book.Authors = authors;

            _dbContext.Book.Add(book);
            _dbContext.SaveChanges();
            return book.Id;
        }
    }
}
