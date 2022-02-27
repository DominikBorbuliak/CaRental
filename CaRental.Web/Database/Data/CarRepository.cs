using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Data
{
    public class CarRepository : ICarRepository
    {
        /// <summary>
        /// Adds new car to the database
        /// If car with provided VIN exists throw user exception
        /// </summary>
        /// <param name="car"></param>
        /// <exception cref="UserException"></exception>
        public void AddCar(Car car)
        {
            using (var database = new CaRentalDBEntities())
            {
                if (database.Cars.Any(carDB => carDB.VIN.Equals(car.VIN)))
                    throw new UserException($"Car with VIN ({car.VIN}) already exists!");

                database.Cars.Add(car);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Finds car by VIN and delets it
        /// If car with provided VIN does not exists throw KeyNotFoundException
        /// </summary>
        /// <param name="VIN"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void DeleteCarByVIN(string VIN)
        {
            using (var database = new CaRentalDBEntities())
            {
                var carToDelete = database.Cars.FirstOrDefault(carDB => carDB.VIN.Equals(VIN));

                if (carToDelete == null)
                    throw new KeyNotFoundException($"Car with VIN ({VIN}) not fount!");

                database.Cars.Remove(carToDelete);
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Delets car entity from database
        /// </summary>
        /// <param name="car"></param>
        public void DeleteCar(Car car)
        {
            using (var database = new CaRentalDBEntities())
            {
                database.Cars.Remove(car);
                database.SaveChanges();
            } 
        }

        /// <summary>
        /// Returns all cars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetAllCars()
        {
            var cars = new List<Car>();
            using (var database = new CaRentalDBEntities())
                cars.AddRange(database.Cars);
            return cars;
        }

        /// <summary>
        /// Returns all available cars
        /// If no cars available throw UserException
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UserException"></exception>
        public IEnumerable<Car> GetAvailableCars()
        {
            using (var database = new CaRentalDBEntities())
            {
                var currentDateTime = DateTime.Now;
                var activeRentals = database.Rentals.Where(rentalDB => rentalDB.From < currentDateTime && rentalDB.To > currentDateTime);

                var availableCars = database.Cars.Where(carDB => !activeRentals.Any(rental => rental.VIN.Equals(carDB.VIN)));

                if (availableCars == null || !availableCars.Any())
                    throw new UserException($"No cars available");

                return availableCars;
            }
        }

        /// <summary>
        /// Updates car entity
        /// If car with provided VIN does not exists throw KeyNotFoundException
        /// </summary>
        /// <param name="car"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void UpdateCar(Car car)
        {
            using (var database = new CaRentalDBEntities())
            {
                if (!database.Cars.Any(carDB => carDB.VIN.Equals(car.VIN)))
                    throw new KeyNotFoundException($"Car with VIN ({car.VIN}) not found!");

                database.Cars.Update(car);
                database.SaveChanges();
            }
        }
    }
}
