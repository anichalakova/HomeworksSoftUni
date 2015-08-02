using System.Collections;
using System.Collections.Generic;

namespace _05_Movies.Models
{
    public class MovieUserDTO
    {
        public string Username { get; set; }

        public ICollection<string> FavouriteMovies { get; set; }
    }
}