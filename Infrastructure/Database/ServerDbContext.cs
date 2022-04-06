using Microsoft.EntityFrameworkCore;
using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Infrastructure.Database
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
}