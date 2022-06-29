using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI
{
    public class LibrarySeeder
    {
        private readonly LibraryDbContext _dbContext;

        public LibrarySeeder(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Book.Any())
                {
                    var books = getBooks(); 
                    _dbContext.Book.AddRange(books);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Book> getBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "FAIRY TALE",
                    Description = "decription",
                    ReleaseDate = DateTime.Now,
                    Authors = new List<Author>()
                    {
                        new Author()
                        {
                            FirstName = "Stephen",
                            Surname = "King",
                        }
                    }
                }
            };
            return books;
        }

    }
}
