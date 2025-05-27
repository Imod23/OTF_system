using Microsoft.EntityFrameworkCore;
using OTF_System.Models;

namespace OTF_System.Data
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Driver { get; set; }
        public DbSet<PoliceOfficer> PoliceOfficer { get; set; }
        public DbSet<Fine> Fine { get; set; }
        public DbSet<Payment> Payment { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Driver
            modelBuilder.Entity<Driver>()
                .HasKey(d => d.LicenceNo);

            // Configure PoliceOfficer
            modelBuilder.Entity<PoliceOfficer>()
                .HasKey(p => p.PoliceID);

            // Configure Fine
            modelBuilder.Entity<Fine>()
                .HasKey(f => f.FineID);

            // Configure Payment
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentID); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
