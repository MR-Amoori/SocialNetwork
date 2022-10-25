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
        [MaxLength(15)]
        [MinLength(5, ErrorMessage = $"The field password must be a string with a minimum length of '5'.")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        public string ConfrimPassword { get; set; }
    }
}
