using AspNetCoreHero.ToastNotification.Abstractions;
using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult List()
        {
            var isAdmin = bool.Parse(HttpContext.Session.GetString("IsAdmin") ?? "false");

            var cars = _databaseService.GetAllCars();
            var viewModel = new CarListViewModel
            {
                Cars = cars
            };

            return View(viewModel);
        }

        public IActionResult OnAddCarSubmit(Car car)
        {
            try
            {
                _databaseService.AddCar(car);
                _notificationService.Success("Car was succesfully created.");
            }
            catch (UserException exception)
            {
                _notificationService.Error(exception.Message);
            }
            catch
            {
                _notificationService.Error("Unexpected error occured! Please contact administrator.");
            }

            return RedirectToAction("List");
        }

        public IActionResult OnUpdateCarSubmit(Car car)
        {
            try
            {
                _databaseService.UpdateCar(car);
                _notificationService.Success("Car was succesfully updated.");
            }
            catch (UserException exception)
            {
                _notificationService.Error(exception.Message);
            }
            catch
            {
                _notificationService.Error("Unexpected error occured! Please contact administrator.");
            }

            return RedirectToAction("List");
        }

        public IActionResult OnDeleteCarClick(Car car)
        {
            try
            {
                _databaseService.DeleteCar(car);
                _notificationService.Success("Car was succesfully deleted.");
            }
            catch (UserException exception)
            {
                _notificationService.Error(exception.Message);
            }
            catch
            {
                _notificationService.Error("Unexpected error occured! Please contact administrator.");
            }

            return RedirectToAction("List");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Index");
        }
    }
}