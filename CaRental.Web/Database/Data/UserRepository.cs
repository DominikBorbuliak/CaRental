using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;
using CaRental.Web.Extensions;

namespace CaRental.Web.Database.Data
{
	public class UserRepository : IUserRepository
	{
		/// <summary>
		/// Find user by email.
		/// Throws UserException when user with provided email does not exists.
		/// </summary>
		/// <param name="userEmail">User email for search</param>
		/// <returns>User with provided email</returns>
		/// <exception cref="UserException"></exception>
		public User GetUserByEmail(string userEmail)
		{
			using (var database = new CaRentalDBEntities())
			{
				var user = database.Users.FirstOrDefault(user => user.Email.Equals(userEmail));

				if (user == null)
					throw new UserException($"User with email ({userEmail}) not found!");

				return user;
			}
		}

		/// <summary>
		/// Adds new user to the database
		/// If user with current email exists throw UserException
		/// </summary>
		/// <param name="user"></param>
		/// <exception cref="UserException"></exception>
		public void AddUser(User user)
		{
			using (var database = new CaRentalDBEntities())
			{
				if (database.Users.Any(userDB => userDB.Email.Equals(user.Email)))
					throw new UserException($"User with email ({user.Email}) already exists!");

				user.Password = user.Password.ConvertToSha256Hash();

				database.Users.Add(user);
				database.SaveChanges();
			}
		}
	}
}
