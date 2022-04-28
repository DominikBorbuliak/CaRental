namespace CaRental.Web.Database.Models
{
	/// <summary>
	/// Exceptions that will be shown to user as notifications
	/// </summary>
	public class UserException : Exception
	{
		public UserException() { }

		public UserException(string message) : base(message) { }

		public UserException(string message, Exception inner) : base(message, inner) { }
	}
}
