using Microsoft.AspNetCore.Mvc;

namespace CaRental.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
