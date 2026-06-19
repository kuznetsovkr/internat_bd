using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
