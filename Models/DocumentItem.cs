using System;
using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class DocumentItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(300)]
        [DataType(DataType.Url)]
        public string FileUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
    }
}
