using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<AuthorsDto> Authors { get; set; }
    }
}
