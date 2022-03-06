namespace CaRental.Web.Database.Models
{
    public class CarFilter
    {
        public string? Manufacturer { get; set; } = null;
        public CarType? Type { get; set; } = null;
        public FuelType? FuelType { get; set; } = null;
        public int? ManufacturedFrom { get; set; } = null;
        public int? ManufacturedTo { get; set; } = null;
        public double? PriceFrom { get; set; } = null;
        public double? PriceTo { get; set; } = null;
        public DateTime? RentFrom { get; set; } = null;
        public DateTime? RentTo { get; set; } = null;
    }
}
