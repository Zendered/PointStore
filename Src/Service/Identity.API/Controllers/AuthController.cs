using Identity.API.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterViewModel userRegister)
        {

            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                Email = userRegister.Email,
                UserName = userRegister.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel userLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(
                userLogin.Email,
                userLogin.Password,
                false,
                true
                );

            return result.Succeeded ? Ok() : BadRequest();
        }
    }
}
