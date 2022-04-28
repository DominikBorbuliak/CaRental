using CaRental.Web.Database.Models;

namespace CaRental.Web.Models
{
	public class CarListViewModel
	{
		public CarFilter Filter { get; set; } = new CarFilter();
		public IEnumerable<Car> Cars = new List<Car>();
	}
}
