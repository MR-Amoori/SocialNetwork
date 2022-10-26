using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-Z]).{5}$",
         ErrorMessage = "Password must meet requirements")]
        [MaxLength(15)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        public string FullName { get; set; }


        [MaxLength(350)]
        public string Biography { get; set; }

        [Required]
        public DateTime CreateDateAccount { get; set; }

        [DefaultValue(false)]
        public bool IsDeletedAccount { get; set; }


        public List<Followre> Followres { get; set; }
        public List<Following> Followings { get; set; }
        public List<Post> Posts { get; set; }
    }

}
