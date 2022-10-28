using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DataLayer.ViewModels
{
    public class AddPostViewModel
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostTitle { get; set; }

        [Required]
        [MaxLength(500)]
        public string PostDescription { get; set; }
    }
}
