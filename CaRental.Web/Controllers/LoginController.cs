using AspNetCoreHero.ToastNotification.Abstractions;
using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Extensions;
using CaRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaRental.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDatabaseService _databaseService;
        private readonly INotyfService _notificationService;

        public LoginController(IDatabaseService databaseService, INotyfService notificationService)
        {
            _databaseService = databaseService;
            _notificationService = notificationService;
        }

        public IActionResult Index(string userEmail = "")
        {
            if (string.IsNullOrEmpty(userEmail))
                return View();

            return View(new User() { Email = userEmail });
        }

        /// <summary>
        /// Check user credentials and redirect to main page after successfull autentification
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult OnLoginSubmit(User user)
        {
            try
            {
                var userDB = _databaseService.GetUserByEmail(user.Email);

                // Check if passwords match
                if (user.Password.ConvertToSha256Hash().Equals(userDB.Password))
                {
                    HttpContext.Session.SetString("UserEmail", userDB.Email);
                    HttpContext.Session.SetString("IsAdmin", userDB.IsAdmin.ToString());
                    _notificationService.Success("You have been logged in successfully!");
                }
                else
                {
                    _notificationService.Error("Incorrect password! Please try again.");
                    return View("Index");
                }
            }
            catch (UserException exception)
            {
                _notificationService.Error(exception.Message);
                return View("Index");
            }
            catch
            {
                _notificationService.Error("Unexpected error occured! Please contact administrator.");
                return View("Index");
            }

            // Redirect to main page after successfull person
            // TODO: fix sending informations
            return RedirectToAction("List", "Car", new CarListViewModel());
        }
    }
}
