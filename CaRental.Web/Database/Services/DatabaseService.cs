using CaRental.Web.Database.Contracts;

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
    }
}
