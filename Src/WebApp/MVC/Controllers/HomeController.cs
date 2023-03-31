using Microsoft.AspNetCore.Mvc;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("error/{id:length(3,3)}")]
    public IActionResult Error(int id)
    {
        var modelError = new ErrorViewModel();

        if (id == 500)
        {
            modelError.Message = "Unfortunately, an error has happened! Try again in a few moment or contact our support.";
            modelError.Title = "An error has happened!";
            modelError.ErrorCode = id;
        }
        else if (id == 404)
        {
            modelError.Message =
                "The page you are looking for doesn't exist! <br />If you think this couldn't happen contact our support";
            modelError.Title = "Ops! Page not found.";
            modelError.ErrorCode = id;
        }
        else if (id == 403)
        {
            modelError.Message = "You cant do this.";
            modelError.Title = "Access Denied";
            modelError.ErrorCode = id;
        }
        else
        {
            return StatusCode(404);
        }

        return View("Error", modelError);
    }
}
