using System;
using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class NewsItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string ShortDescription { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [StringLength(300)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
