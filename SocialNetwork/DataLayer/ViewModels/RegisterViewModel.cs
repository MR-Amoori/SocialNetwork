using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Remote("VerifyUserName", "Account")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote("VerifyEmail", "Account")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z]).{5,}$",
         ErrorMessage = "Password must meet requirements")]
        [MaxLength(15)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [MaxLength(15)]
        [MinLength(5)]
        [DisplayName("Confrim Password")]
        public string ConfrimPassword { get; set; }

    }
}
