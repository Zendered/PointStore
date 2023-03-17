using Microsoft.AspNetCore.Mvc;
using WebApp.MVC.Models.AccountViewModels;

namespace WebApp.MVC.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel userRegister)
        {
            if (!ModelState.IsValid) return View();

            if (false) return View(userRegister);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel userLogin)
        {
            if (!ModelState.IsValid) return View();

            if (false) return View(userLogin);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
