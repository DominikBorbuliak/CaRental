using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Contracts
{
	public interface IRentalRepository
	{
		void AddRental(Rental rental);
	}
}
