using System.ComponentModel.DataAnnotations;

namespace _05_Movies.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}