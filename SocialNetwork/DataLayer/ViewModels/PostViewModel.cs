using SocialNetwork.DataLayer.Models;

namespace SocialNetwork.DataLayer.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public Comment Comment { get; set; }
    }
}
