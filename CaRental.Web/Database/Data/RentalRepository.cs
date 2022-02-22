using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Models;

namespace CaRental.Web.Database.Data
{
    public class RentalRepository : IRentalRepository
    {
        /// <summary>
        /// Adds new rental
        /// If car picked for rental is at some point rented by someone else throw new UserException
        /// </summary>
        /// <param name="rental"></param>
        /// <exception cref="UserException"></exception>
        public void AddRental(Rental rental)
        {
            using (var database = new CaRentalDBEntities())
            {
                var activeRentForCar = database.Rentals.FirstOrDefault(rentalDB => rentalDB.VIN.Equals(rental.VIN) && 
                                                                        ((rentalDB.To > rental.From && rentalDB.To < rental.To) || 
                                                                        (rentalDB.From < rental.To && rentalDB.From > rental.From)));
                
                if (activeRentForCar != null)
                    throw new UserException($"Can not rent this car because it is already rented from: '{activeRentForCar.From}' to: '{activeRentForCar.To}'!");

                database.Add(rental);
            }
        }
    }
}
