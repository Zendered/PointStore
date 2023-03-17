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
            return View();
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
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
