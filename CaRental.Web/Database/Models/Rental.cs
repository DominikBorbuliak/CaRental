using System.ComponentModel.DataAnnotations.Schema;

namespace CaRental.Web.Database.Models
{
    public class Rental
    {
        /// <summary>
        /// PrimaryKey
        /// Rental starts at day and time
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// PrimaryKey
        /// Rental ends at day and time
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// PrimaryKey, ForeignKey
        /// Vin of rented car
        /// </summary>
        [ForeignKey("Car")]
        [Column(TypeName = "VARCHAR (17)")]
        public string VIN { get; set; }
        public Car Car { get; set; }

        /// <summary>
        /// PrimaryKey, ForeignKey
        /// User email that performed rental
        /// </summary>
        [ForeignKey("User")]
        [Column(TypeName = "VARCHAR (60)")]
        public string Email { get; set; }
        public User User { get; set; }
    }
}
