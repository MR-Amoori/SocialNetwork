using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.Repositories;
using SocialNetwork.DataLayer.ViewModels.Account;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _repository;
        private readonly IMessageSenderRepository _messageSenderRepository;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserRepository repository, IMessageSenderRepository messageSenderRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
            _messageSenderRepository = messageSenderRepository;
        }


        [HttpGet]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                //if (_repository.UserEmailExists(model.Email))
                //{
                //    ModelState.AddModelError("Email", "This email is already registered");
                //    return View(model);
                //}

                //if (_repository.UserNameExists(model.UserName))
                //{
                //    ModelState.AddModelError("UserName", "This username is already registered");
                //    return View(model);
                //}

                User user1 = new()
                {
                    UserName = model.UserName,
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    CreateDateAccount = DateTime.Now,
                    IsDeletedAccount = false,
                };


                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //var emailConfrimationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var emailMessage =
                    //    Url.Action("ConfrimEmail", "Account",
                    //    new { username = user.UserName, token = emailConfrimationToken }, Request.Scheme);
                    //await _messageSenderRepository.SendEmailAsync(model.Email, "Email Confrimation", emailMessage);

                    ViewData["SendEmailConfrimation"] = "A confirmation email has been sent to you";

                    _repository.AddUser(user1);
                    _repository.Save();
                    return RedirectToAction("Login", "Account");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfrimEmail(string username, string token)
        {
            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            ViewData["EmailConfrim"] = "Your email has been confirmed";
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["returnUrl"] = returnUrl;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }


            ViewData["returnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "You have failed 5 times. Try after 15 minutes.";
                    return View(model);
                }


                ModelState.AddModelError("", "The password or username is incorrect");
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result == null)
            {
                return Json(true);
            }
            return Json("This email is already registered");
        }


        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            var result = await _userManager.FindByNameAsync(username);
            if (result == null)
            {
                return Json(true);
            }
            return Json("This username is already registered");
        }

    }
}
