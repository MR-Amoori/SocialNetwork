using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.Models
{
    public class Following
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
