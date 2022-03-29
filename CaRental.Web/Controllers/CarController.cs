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

        [HttpGet]
        public IActionResult List(CarListViewModel viewModel, bool resetFilters = false)
        {
            if (resetFilters)
            {
                viewModel.Filter.Manufacturer = null;
                viewModel.Filter.Type = null;
                viewModel.Filter.FuelType = null;
                viewModel.Filter.ManufacturedFrom = 2000;
                viewModel.Filter.ManufacturedTo = DateTime.Now.Year;
                viewModel.Filter.PriceFrom = 0;
                viewModel.Filter.PriceTo = 999.99;

                var currentDateTime = DateTime.Now;
                var currentDateTimeFormatted = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, currentDateTime.Minute, 0);
                viewModel.Filter.RentFrom = currentDateTimeFormatted;
                viewModel.Filter.RentTo = currentDateTimeFormatted;
            }
            
            viewModel.Cars = _databaseService.GetCarsWithFilter(viewModel.Filter);

            ViewData["RentCarFrom"] = (viewModel.Filter.RentFrom ?? DateTime.Now).ToString("yyyy-MM-ddTHH:mm");
            ViewData["RentCarTo"] = (viewModel.Filter.RentTo ?? DateTime.Now).ToString("yyyy-MM-ddTHH:mm");

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

        public IActionResult OnRentCarSubmit(RentalViewModel rental)
        {
            try
            {
                _databaseService.AddRental(new Rental
                {
                    VIN = rental.VIN,
                    Email = rental.Email,
                    From = rental.From,
                    To = rental.To,
                    Price = double.Parse(rental.TotalPrice.Split(" ")[0])
                });

                _notificationService.Success("Car was successfully rented.");
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