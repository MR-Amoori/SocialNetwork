using Microsoft.EntityFrameworkCore;
using SocialNetwork.Context;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.Repositories;

namespace SocialNetwork.DataLayer.Services
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialContext _context;

        public PostRepository(SocialContext context)
        {
            _context = context;
        }

        public bool AddComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddPost(Post post)
        {
            try
            {
                _context.Posts.Add(post);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePost(Post post)
        {
            try
            {
                _context.Posts.Find(post).IsDeletedPost = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePost(int postId)
        {
            return DeletePost(GetPostByPostId(postId));
        }

        public Post GetPostByPostId(int postId)
        {
            return _context.Posts.Where(p => !p.IsDeletedPost).FirstOrDefault(p => p.PostId == postId);
        }

        public IEnumerable<Post> GetPostsByUserId(int userId)
        {
            var post = _context.Posts.Include(p => p.User)
                .Include(p => p.comments).Where(p => !p.IsDeletedPost)
                .Where(p => p.User.Id == userId).ToList();
            return post;
        }

        public string GetUserNameById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId).UserName;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdatePost(Post post)
        {
            try
            {
                _context.Posts.Update(post);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
