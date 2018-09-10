using CarManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarManager.Data
{
    public class CarManagerDbContext : IdentityDbContext<User>
    {
        public CarManagerDbContext(DbContextOptions<CarManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Refueling> Refuelings { get; set; }

        public DbSet<ServiceData> ServiceDatas { get; set; }

        public DbSet<TaxName> TaxNames { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleTax> VehicleTaxes { get; set; }

        //public DbSet<VehicleType> VehicleTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<>

        //    base.OnModelCreating(builder);
        //}
    }
}
