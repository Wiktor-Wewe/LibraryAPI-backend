using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
