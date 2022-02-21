using Microsoft.EntityFrameworkCore;

namespace CaRental.Web.Database.Models
{
    public class CaRentalDBEntities : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=CaRentalDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys for Rentals
            modelBuilder.Entity<Rental>()
                .HasKey(c => new { c.From, c.To, c.VIN, c.Email });
        }

    }
}
