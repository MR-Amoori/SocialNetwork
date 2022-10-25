using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Followre
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public User User { get; set; }
    }

}
