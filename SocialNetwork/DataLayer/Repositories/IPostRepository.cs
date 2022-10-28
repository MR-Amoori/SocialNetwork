using SocialNetwork.DataLayer.Models;

namespace SocialNetwork.DataLayer.Repositories
{
    public interface IPostRepository
    {
        public bool AddPost(Post post);
        public bool UpdatePost(Post post);
        public bool DeletePost(Post post);
        public bool DeletePost(int postId);

        public string GetUserNameById(int userId);

        public bool AddComment(Comment comment);

        public IEnumerable<Post> GetPostsByUserId(int userId);
        public Post GetPostByPostId(int postId);
        public void Save();
    }
}
