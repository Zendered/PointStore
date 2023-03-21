using Microsoft.AspNetCore.Mvc;
using WebApp.MVC.Models.AccountViewModels;
using WebApp.MVC.Services;

namespace WebApp.MVC.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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
            if (!ModelState.IsValid) return View(userRegister);

            var response = await _authenticationService.Register(userRegister);

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
            if (!ModelState.IsValid) return View(userLogin);

            var response = await _authenticationService.Login(userLogin);

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
