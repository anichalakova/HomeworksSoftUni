using System;
using System.ComponentModel.DataAnnotations;

namespace News.Data
{
    public class NewsItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        //if DateTime is not required, use DateTime? (nullable)
        public DateTime PublishDate { get; set; }
    }
}
