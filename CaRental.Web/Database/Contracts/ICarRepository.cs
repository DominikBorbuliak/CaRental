using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Contracts
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetAllCars();
		IEnumerable<Car> GetCarsWithFilter(CarFilter filter);
		void AddCar(Car car);
		void DeleteCarByVIN(string VIN);
		void DeleteCar(Car car);
		void UpdateCar(Car car);
	}
}
