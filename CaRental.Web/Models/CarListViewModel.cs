using CaRental.Web.Database.Models;

namespace CaRental.Web.Models
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars = new List<Car>();
    }
}
