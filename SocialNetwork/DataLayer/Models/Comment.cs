using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [StringLength(150)]
        public string CommentText { get; set; }

        [Required]
        public int UserIdFrom { get; set; }

        [Required]
        public string UserNameFrom { get; set; }

        [Required]
        public int UserIdTo { get; set; }

        [Required]
        public string UserNameTo { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }

}
