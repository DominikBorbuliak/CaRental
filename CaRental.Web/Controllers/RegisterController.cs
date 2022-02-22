using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Data;
using CaRental.Web.Database.Models;
using CaRental.Web.Database.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IDatabaseService _databaseService;

        public RegisterController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser(User user)
        {
            _databaseService.AddUser(user);
            return null;
        }
    }
}
