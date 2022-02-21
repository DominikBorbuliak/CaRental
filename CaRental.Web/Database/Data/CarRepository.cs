using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Data
{
    public class CarRepository : ICarRepository
    {
        public void AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void DeleteCarByVIN(string VIN)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAvailableCars()
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
