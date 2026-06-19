using System.ComponentModel.DataAnnotations;

namespace internat_bd.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
