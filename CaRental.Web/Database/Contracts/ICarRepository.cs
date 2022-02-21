using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Contracts
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetAvailableCars();
        void AddCar(Car car);
        void DeleteCarByVIN(string VIN);
        void UpdateCar(Car car);
    }
}
