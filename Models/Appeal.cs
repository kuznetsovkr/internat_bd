using System;
using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class Appeal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
