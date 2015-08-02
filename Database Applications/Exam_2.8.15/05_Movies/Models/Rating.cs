using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_Movies.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Stars must be in range 0 to 10!")]
        public int Stars { get; set; }

        [Index("IX_UserAndMovie", 1, IsUnique = true)]
        public int UserId { get; set; }
        public virtual User User{ get; set; }

        [Index("IX_UserAndMovie", 2, IsUnique = true)]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}