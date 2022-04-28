namespace CaRental.Web.Models
{
	public class RentalViewModel
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public string VIN { get; set; }
		public string Email { get; set; }
		public string TotalPrice { get; set; }
		public string PricePerHour { get; set; }
	}
}
