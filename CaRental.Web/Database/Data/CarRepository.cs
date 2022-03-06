using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Extensions;

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
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="UserException"></exception>
        public IEnumerable<Car> GetCarsWithFilter(CarFilter filter)
        {
            var cars = new List<Car>();

            using (var database = new CaRentalDBEntities())
            {
                var carsDB = database.Cars as IEnumerable<Car>;

                if (!string.IsNullOrEmpty(filter?.Manufacturer))
                    carsDB = carsDB.Where(car => car.Manufacturer.Equals(filter.Manufacturer));
                if (filter?.Type != null)
                    carsDB = carsDB.Where(car => car.Type == filter.Type);
                if (filter?.FuelType != null)
                    carsDB = carsDB.Where(car => car.FuelType == filter.FuelType);
                if (filter?.ManufacturedFrom != null)
                    carsDB = carsDB.Where(car => car.YearOfManufacture >= filter.ManufacturedFrom);
                if (filter?.ManufacturedTo != null)
                    carsDB = carsDB.Where(car => car.YearOfManufacture <= filter.ManufacturedTo);
                if (filter?.PriceFrom != null)
                    carsDB = carsDB.Where(car => car.RentalPrice >= filter.PriceFrom);
                if (filter?.PriceTo != null)
                    carsDB = carsDB.Where(car => car.RentalPrice <= filter.PriceTo);
                if (filter?.RentFrom != null && filter?.RentTo != null)
                {
                    var rentFrom = filter.RentFrom ?? DateTime.Now;
                    var rentTo = filter.RentTo ?? DateTime.Now;

                    var activeRentals = database.Rentals.ToList().Where(rentalDB => rentalDB.From.IsBetween(rentFrom, rentTo) || rentalDB.To.IsBetween(rentFrom, rentTo) || (rentalDB.From < rentFrom && rentalDB.To > rentTo)).Select(car => car.VIN).Distinct();

                    carsDB = carsDB.Where(car => !activeRentals.Contains(car.VIN));
                }

                cars.AddRange(carsDB);
            }

            return cars;

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
