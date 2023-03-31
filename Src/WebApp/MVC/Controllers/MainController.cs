using Microsoft.AspNetCore.Mvc;
using WebApp.MVC.Models;

namespace WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool HasError(ResponseResult response)
        {
            if (response is not null && response.Errors.Messages.Any())
            {
                return true;
            }
            return false;
        }
    }
}
