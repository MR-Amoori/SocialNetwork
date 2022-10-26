using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Remote(action: "IsUsernameInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(15)]
        [MinLength(5, ErrorMessage = $"The field Password must be a string with a minimum length of '5'.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfrimPassword { get; set; }
    }
}
