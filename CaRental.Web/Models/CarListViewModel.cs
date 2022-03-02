using CaRental.Web.Database.Models;
using System.ComponentModel;

namespace CaRental.Web.Models
{
    public class CarListViewModel
    {
        // Filters
        public string? Manufacturer { get; set; } = null;
        public CarType? Type { get; set; } = null;
        public FuelType? FuelType { get; set; } = null;
        public int? ManufacturedFrom { get; set; }
        public int? ManufacturedTo { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }

        public IEnumerable<Car> Cars = new List<Car>();
    }
}
