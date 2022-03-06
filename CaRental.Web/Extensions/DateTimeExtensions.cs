namespace CaRental.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime input, DateTime min, DateTime max)
        {
            return input >= min && input <= max;
        }
    }
}
