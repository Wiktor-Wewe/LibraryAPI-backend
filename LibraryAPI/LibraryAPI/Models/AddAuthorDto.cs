using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class AddAuthorDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
