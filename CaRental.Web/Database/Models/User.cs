using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaRental.Web.Database.Models
{
	public class User
	{
		/// <summary>
		/// PrimaryKey
		/// User's email
		/// </summary>
		[Key]
		[Column(TypeName = "VARCHAR (60)")]
		[MaxLength(60)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		/// <summary>
		/// User's name
		/// </summary>
		[Column(TypeName = "VARCHAR (50)")]
		[MaxLength(50)]
		public string Name { get; set; }

		/// <summary>
		/// User's surname
		/// </summary>
		[Column(TypeName = "VARCHAR (50)")]
		[MaxLength(50)]
		public string Surname { get; set; }

		/// <summary>
		/// User's date of birth
		/// </summary>
		[Column(TypeName = "DATETIME")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Hashed password of the user
		/// </summary>
		[Column(TypeName = "VARCHAR (43)")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		/// <summary>
		/// Determines whether user is admin or not
		/// </summary>
		[Column(TypeName = "BOOLEAN")]
		public bool IsAdmin { get; set; }
	}
}
