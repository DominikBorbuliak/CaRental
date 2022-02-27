using AspNetCoreHero.ToastNotification.Abstractions;
using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaRental.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IDatabaseService _databaseService;
        private readonly INotyfService _notificationService;

        public CarController(IDatabaseService databaseService, INotyfService notificationService)
        {
            _databaseService = databaseService;
            _notificationService = notificationService;
        }

        public IActionResult List(string userEmail, string isAdmin)
        {
            // Setup variables
            ViewData["UserEmail"] = userEmail;
            ViewData["IsAdmin"] = isAdmin;

            var cars = _databaseService.GetAllCars();
            var viewModel = new CarListViewModel
            {
                Cars = cars
            };

            return View(viewModel);
        }

        public IActionResult Logout()
        {
            ViewData.Clear();
            return RedirectToAction("Login", "Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}