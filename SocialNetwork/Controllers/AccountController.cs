using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.Repositories;
using SocialNetwork.DataLayer.ViewModels;
using System.Security.Claims;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _repository;

        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }


        #region Validation

        public async Task<IActionResult> VerifyUserName(string username)
        {
            if (_repository.UserNameExists(username))
            {
                return Json("This username is already registered !");
            }
            return Json(true);
        }


        public async Task<IActionResult> VerifyEmail(string email)
        {
            if (_repository.UserEmailExists(email))
            {
                return Json("This Email is already registered !");
            }
            return Json(true);
        }


        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_repository.UserNameExists(model.UserName))
                {
                    ModelState.AddModelError("", "This username is already registered");
                    return View(model);
                }

                if (_repository.UserEmailExists(model.Email))
                {
                    ModelState.AddModelError("", "This email is already registered");
                    return View(model);
                }

                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email.ToLower(),
                    FullName = model.FullName,
                    CreateDateAccount = DateTime.Now,
                    Password = model.Password
                };

                _repository.AddUser(user);
                _repository.Save();
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "There is a problem in sending information");
            return View(model);
        }

        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = _repository.GetUserForLogin(model.Email, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                    return View(model);
                }
                if (user != null)
                {
                    if (user.Password != model.Password)
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");
                        return View(model);
                    }

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name , user.UserName),
                        new Claim("FullName",user.FullName),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    returnUrl = String.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
                    return Redirect(returnUrl);
                }
            }

            ModelState.AddModelError("", "There is a problem in sending information");
            return View(model);
        }

        #endregion

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion

    }
}
