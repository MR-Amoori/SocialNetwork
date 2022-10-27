using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z]).{5,}$", ErrorMessage = "Password must meet requirements")]
        [MaxLength(15)]
        [MinLength(5)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
