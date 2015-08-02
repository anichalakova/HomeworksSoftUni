using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_Movies.Models
{
    public class User
    {
        public User()
        {
            this.FavouriteMovies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long!")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        [Range(0, 150, ErrorMessage = "Age must be in the range 0 to 150!")]
        public int Age { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> FavouriteMovies { get; set; }
    }
}