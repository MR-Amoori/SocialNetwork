using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.Repositories;
using SocialNetwork.DataLayer.ViewModels;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _userRepository;

        public DashboardController(IPostRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var posts = _repository.GetPostsByUserId(int.Parse(User.Identity.GetUserId()));
            PostViewModel post = new()
            {
                Posts = posts,
            };
            if (posts.Any())
                return View(post);
            else
                return View();
        }

        public IActionResult UserDev(int Id)
        {
            var user = _userRepository.GetUserById(Id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult AddComment(PostViewModel post, string path)
        {
            if (true)
            {
                if (post.Comment != null)
                {
                    string usernameFrom = _repository.GetUserNameById(post.Comment.UserIdFrom);
                    Comment comment = new()
                    {
                        CommentText = post.Comment.CommentText,
                        PostId = post.Comment.PostId,
                        UserIdFrom = post.Comment.UserIdFrom,
                        UserIdTo = post.Comment.UserIdTo,
                        UserNameFrom = usernameFrom,
                        UserNameTo = post.Comment.UserNameTo,
                    };
                    _repository.AddComment(comment);
                    _repository.Save();
                }

                if (!String.IsNullOrEmpty(path))
                {
                    return Redirect(path);
                }
            }

            return View(post);
        }

        //
        public IActionResult Details(int postId)
        {
            return View();
        }
        //
        public IActionResult Delete(int postId)
        {
            return View();
        }



        #region Add Post

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            Post post1 = new()
            {
                CreateDate = DateTime.Now,
                UserId = int.Parse(User.Identity.GetUserId()),
                PostTitle = post.PostTitle,
                PostDescription = post.PostDescription,
            };

            _repository.AddPost(post1);
            _repository.Save();

            return RedirectToAction("Index", "Dashboard");
        }

        #endregion

    }
}
