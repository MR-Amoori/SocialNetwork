using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SocialNetwork.DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

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
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        [AllowNull]
        [MaxLength(250)]
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
