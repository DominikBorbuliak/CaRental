using AspNetCoreHero.ToastNotification.Abstractions;
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
		private readonly INotyfService _notificationService;

		public RegisterController(IDatabaseService databaseService, INotyfService notificationService)
		{
			_databaseService = databaseService;
			_notificationService = notificationService;
		}

		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Creates user when register button was pressed and redirect to login page
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public IActionResult OnRegisterSubmit(User user)
		{
			try
			{
				_databaseService.AddUser(user);
				_notificationService.Success("Account created successfully. Pleas log in.");
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

			return RedirectToAction("Index", "Login", new { userEmail = user.Email });
		}
	}
}
