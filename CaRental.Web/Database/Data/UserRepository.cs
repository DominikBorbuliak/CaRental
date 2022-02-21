using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Data
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Find user by email.
        /// Throws KeyNotFoundException when user with provided email does not exists.
        /// </summary>
        /// <param name="userEmail">User email for search</param>
        /// <returns>User with provided email</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public User GetUserByEmail(string userEmail)
        {
            using (var database = new CaRentalDBEntities())
            {
                var user = database.Users.FirstOrDefault(user => user.Email.Equals(userEmail));

                if (user == null)
                    throw new KeyNotFoundException($"User with email: '{userEmail}' not found!");

                return user;
            }
        }
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
