using CarAuctionMVC.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAuctionMVC.Application.Context
{
    public class CarAuctionMVCDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBody> CarBodies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }

        public CarAuctionMVCDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
