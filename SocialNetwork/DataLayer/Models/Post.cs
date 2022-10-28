using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostTitle { get; set; }


        public string? PostImage { get; set; }

        [Required]
        [MaxLength(500)]
        public string PostDescription { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsDeletedPost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> comments { get; set; }
    }

}
