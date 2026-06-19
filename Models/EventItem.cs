using System;
using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class EventItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [StringLength(150)]
        public string Place { get; set; }
    }
}
