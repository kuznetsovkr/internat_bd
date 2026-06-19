using System;
using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int SchoolClassId { get; set; }

        public SchoolClass SchoolClass { get; set; }
    }
}
