using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaRental.Web.Database.Models
{
    public class Car
    {
        /// <summary>
        /// PrimaryKey
        /// VIN number of car
        /// exactly 17 characters
        /// </summary>
        [Key]
        [Column(TypeName = "VARCHAR (17)")]
        [DataType(DataType.Text)]
        [MinLength(17)]
        [MaxLength(17)]
        public string VIN { get; set; }

        /// <summary>
        /// Manufacturer of the car
        /// e.g. BMW, Ford, Wolkswagen 
        /// </summary>
        [Column(TypeName = "VARCHAR (20)")]
        [DataType(DataType.Text)]
        [MaxLength(17)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Model of the car
        /// e.g. (AUDI) A6, (Citroen) C3, (Hyundai) I30
        /// </summary>
        [Column(TypeName = "VARCHAR (20)")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Model { get; set; }

        /// <summary>
        /// Type of car
        /// e.g. Hatchback, Fastback, Combi
        /// </summary>
        [Column(TypeName = "INT (2)")]
        [EnumDataType(typeof(CarType))]
        public CarType Type { get; set; } = CarType.Unknown;

        /// <summary>
        /// Fuel type
        /// e.g. Gasoline, Diesel, LPG
        /// </summary>
        [Column(TypeName = "INT (2)")]
        [EnumDataType(typeof(FuelType))]
        public FuelType FuelType { get; set; } = FuelType.Gasoline;

        /// <summary>
        /// Description of the car
        /// e.g. Motor: 1.4I, 5 seats
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        /// <summary>
        /// Year of manufacture of the car
        /// </summary>
        [Column(TypeName = "INT (4)")]
        [Range(2000, 2022)]
        public int YearOfManufacture { get; set; }

        /// <summary>
        /// Rental price per hour
        /// </summary>
        [Column(TypeName = "DOUBLE(3, 2)")]
        [Range(0.01, 999.99)]
        public double RentalPrice { get; set; }

        /// <summary>
        /// Url to car image
        /// </summary>
        [Column(TypeName = "VARCHAR (255)")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(255)]
        public string ImageUrl { get; set; }
    }

    public enum FuelType
    {
        Gasoline,
        Diesel,
        LPG,
        Hybrid,
        Electric
    }

    public enum CarType
    {
        Unknown,
        Combi,
        Convertible,
        Coupe,
        Crossover,
        Fastback,
        Hatchback,
        Limousine,
        Luxury,
        MPV,
        Pickup,
        SUV,
        Sedan,
        Wagon
    }
}
