using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
