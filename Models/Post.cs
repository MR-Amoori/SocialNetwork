using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostTitle { get; set; }

        [Required]
        public string PostImage { get; set; }

        [Required]
        [MaxLength(500)]
        public string PostDescription { get; set; }

        [DefaultValue(false)]
        public bool IsDeletedPost { get; set; }

        public User User { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> comments { get; set; }
    }

}
