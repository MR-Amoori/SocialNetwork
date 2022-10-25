using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.Models
{
    public class Like
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }

}
