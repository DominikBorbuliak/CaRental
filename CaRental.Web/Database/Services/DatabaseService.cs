using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;

        public DatabaseService(IUserRepository userRepository, ICarRepository carRepository, IRentalRepository rentalRepository)
        {
            _userRepository = userRepository;
            _carRepository = carRepository;
            _rentalRepository = rentalRepository;
        }

        public void AddCar(Car car) => _carRepository.AddCar(car);

        public void AddRental(Rental rental) => _rentalRepository.AddRental(rental);

        public void AddUser(User user) => _userRepository.AddUser(user);

        public void DeleteCar(Car car) => _carRepository.DeleteCar(car);

        public void DeleteCarByVIN(string VIN) => _carRepository.DeleteCarByVIN(VIN);

        public IEnumerable<Car> GetAllCars() => _carRepository.GetAllCars();

        public IEnumerable<Car> GetCarsWithFilter(CarFilter filter) => _carRepository.GetCarsWithFilter(filter);

        public User GetUserByEmail(string userEmail) => _userRepository.GetUserByEmail(userEmail);

        public void UpdateCar(Car car) => _carRepository.UpdateCar(car);
    }
}
