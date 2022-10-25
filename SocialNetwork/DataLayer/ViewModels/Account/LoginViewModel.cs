using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels.Account
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(15)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
