using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
    }
}
