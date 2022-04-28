using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Contracts
{
	public interface IUserRepository
	{
		User GetUserByEmail(string userEmail);
		void AddUser(User user);
	}
}
