using CarAuctionMVC.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAuctionMVC.Application.Context
{
    public class CarAuctionMVCDbContext : DbContext
    {
        public DbSet<Auction>? Auctions { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<CarBody>? CarBodies { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<EngineType>? EngineTypes { get; set; }

        public CarAuctionMVCDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dsz");

            modelBuilder.Entity<Auction>(a =>
            {
                a.HasOne(a => a.Car)
                    .WithOne(c => c.Auction)
                    .HasForeignKey<Car>(c => c.AuctionId);

                a.Property(a => a.AuctionTittle).IsRequired().HasMaxLength(100);
                a.Property(a => a.AuctionDate).IsRequired();
                a.Property(a => a.BuyNowPrice).IsRequired();
                a.Property(a => a.StartAuctionPrice).IsRequired();
            });

            modelBuilder.Entity<Car>(c =>
            {
                c.Property(c => c.Model).IsRequired().HasMaxLength(30);
                c.Property(c => c.Brand).IsRequired().HasMaxLength(30);
                c.Property(c => c.CountryOfOrigin).IsRequired().HasMaxLength(20);
                c.Property(c => c.DateOfProduction).IsRequired();
                c.Property(c => c.Mileage).IsRequired();
                c.Property(c => c.Color).IsRequired().HasMaxLength(10);
                c.Property(c => c.AuctionId).IsRequired();
                c.Property(c => c.CarBodyId).IsRequired();
                c.Property(c => c.CategoryId).IsRequired();
                c.Property(c => c.EngineTypeId).IsRequired();
            });

            modelBuilder.Entity<CarBody>(cb =>
            {
                cb.Property(cb => cb.NameOfCarBody).IsRequired();
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.Property(c => c.CategoryName).IsRequired();
            });

            modelBuilder.Entity<EngineType>(et =>
            {
                et.Property(et => et.EngineName).IsRequired();
            });
        }
    }
}
