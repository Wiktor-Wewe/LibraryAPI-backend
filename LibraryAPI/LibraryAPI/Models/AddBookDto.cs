using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class AddBookDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
