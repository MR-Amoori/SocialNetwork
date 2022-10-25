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
        private readonly IUserRepository _repository;

        public AccountController(UserManager<IdentityUser> userManager, IUserRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_repository.UserEmailExists(model.Email))
                {
                    ModelState.AddModelError("Email", "This email is already registered");
                    return View(model);
                }

                if (_repository.UserNameExists(model.UserName))
                {
                    ModelState.AddModelError("UserName", "This username is already registered");
                    return View(model);
                }

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
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _repository.AddUser(user1);
                    _repository.Save();
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



    }
}
