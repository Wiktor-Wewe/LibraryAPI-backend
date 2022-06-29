using System.Collections.Generic;

namespace LibraryAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
