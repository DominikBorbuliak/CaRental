using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Contracts
{
    public interface IDatabaseService
    {
        // Car
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetCarsWithFilter(CarFilter filter);
        void AddCar(Car car);
        void DeleteCarByVIN(string VIN);
        void DeleteCar(Car car);
        void UpdateCar(Car car);

        // Rental
        void AddRental(Rental rental);

        // User
        User GetUserByEmail(string userEmail);
        void AddUser(User user);
    }
}
