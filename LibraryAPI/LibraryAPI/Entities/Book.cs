using System;
using System.Collections.Generic;

namespace LibraryAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual List<Author> Authors { get; set; }
    }
}
