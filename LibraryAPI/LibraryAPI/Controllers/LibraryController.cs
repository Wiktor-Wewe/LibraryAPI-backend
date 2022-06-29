using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPut("books/{id}")]
        public ActionResult UpdateBook([FromRoute]int id, [FromBody]UpdateBookDto dto)
        {
            var isUpdated = _libraryService.UpdateBook(id, dto);
            if (!isUpdated) return NotFound();
            return Ok();
        }
        
        [HttpPut("authors/{id}")]
        public ActionResult UpdateAuthor([FromRoute]int id, [FromBody]UpdateAuthorDto dto)
        {
            var isUpdated = _libraryService.UpdateAuthor(id, dto);
            if (!isUpdated) return NotFound();
            return Ok();
        }

        [HttpDelete("books/{id}")]
        public ActionResult DeleteBook([FromRoute]int id)
        {
            var isDeleted = _libraryService.DeleteBook(id);
            if (isDeleted) return NoContent();
            return NotFound();
        }

        [HttpDelete("authors/{id}")]
        public ActionResult DeleteAuthor([FromRoute] int id)
        {
            var isDeleted = _libraryService.DeleteAuthor(id);
            if (isDeleted) return NoContent();
            return NotFound();
        }

        [HttpPost("authors/{id}")]
        public ActionResult AddBook([FromRoute]int id, [FromBody]AddBookDto dto)
        {
            var resultId = _libraryService.AddBook(id, dto);
            return Created($"/api/library/books/{resultId}", null);
        }

        [HttpPost("authors")]
        public ActionResult AddAuthor([FromBody]AddAuthorDto dto)
        {
            var resultId = _libraryService.AddAuthor(dto);
            return Created($"/api/library/authors/{resultId}", null);
        }

        [HttpGet("books")]
        public ActionResult<IEnumerable<BooksDto>> GetAllBooks()
        {
            var booksDtos = _libraryService.GetAllBooks();
            return Ok(booksDtos);
        }

        [HttpGet("authors")]
        public ActionResult<IEnumerable<AuthorsDto>> GetAllAuthors()
        {
            var authorsDto = _libraryService.GetAllAuthors();
            return Ok(authorsDto);
        }

        [HttpGet("books/{id}")]
        public ActionResult<BookDto> GetBookById([FromRoute]int id)
        {
            var bookDto = _libraryService.GetBookById(id);
            if (bookDto is null) return NotFound();
            return Ok(bookDto);
        }

        [HttpGet("authors/{id}")]
        public ActionResult<AuthorDto> GetAuthorById([FromRoute] int id)
        {
            var authorDto = _libraryService.GetAuthorById(id);
            if(authorDto is null) return NotFound();
            return Ok(authorDto);
        }
    }
}
