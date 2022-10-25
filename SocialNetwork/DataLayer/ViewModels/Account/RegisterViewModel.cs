using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$",
        ErrorMessage = "Password must meet requirements")]
        [MaxLength(15)]
        [MinLength(5)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$",
        ErrorMessage = "Password must meet requirements")]
        [MaxLength(15)]
        [MinLength(5)]
        public string ConfrimPassword { get; set; }
    }
}
