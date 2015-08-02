using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_Movies.Models
{
    public enum AgeRestriction
    {
        Child,
        Teen,
        Adult
    }
    public class Movie
    {
        public Movie()
        {
            this.LikedByUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> LikedByUsers { get; set; }
    }
}