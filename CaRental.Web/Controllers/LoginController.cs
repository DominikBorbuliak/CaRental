using AspNetCoreHero.ToastNotification.Abstractions;
using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
                    _notificationService.Success("You have been logged in successfully!");
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

            // Fill informations about user
            ViewData["UserEmail"] = user.Email;
            ViewData["IsAdmin"] = user.IsAdmin;

            // Redirect to main page after successfull person
            return RedirectToAction("Index", "Home");
        }
    }
}
