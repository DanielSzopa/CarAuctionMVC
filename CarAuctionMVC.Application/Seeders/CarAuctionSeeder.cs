using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAuctionMVC.Application.Seeders
{
    public class CarAuctionSeeder : ICarAuctionSeeder
    {
        private readonly CarAuctionMVCDbContext _dbContext;

        public CarAuctionSeeder(CarAuctionMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedData()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!await _dbContext.CarBodies.AnyAsync())
                {
                    var carBodies = GetCarBodiesToSeed();
                    await _dbContext.CarBodies.AddRangeAsync(carBodies);
                    await _dbContext.SaveChangesAsync();
                }

                if (!await _dbContext.Categories.AnyAsync())
                {
                    var categories = GetCategoriesToSeed();
                    await _dbContext.Categories.AddRangeAsync(categories);
                    await _dbContext.SaveChangesAsync();
                }

                if (!await _dbContext.EngineTypes.AnyAsync())
                {
                    var engineTypes = GetEngineTypesToSeed();
                    await _dbContext.EngineTypes.AddRangeAsync(engineTypes);
                    await _dbContext.SaveChangesAsync();
                }

                if (!await _dbContext.Auctions.AnyAsync())
                {
                    var auctions = GetAuctionsToSeed();
                    await _dbContext.Auctions.AddRangeAsync(auctions);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Auction> GetAuctionsToSeed()
        {
            var auctions = new List<Auction>()
            {
                new Auction()
                {
                    AuctionTittle = "Audi a4!! Bardzo dobry stan!!!",
                    AuctionDate = DateTime.Now,
                    Price = 56040,
                    Car = new Car()
                    {
                        Model = "A4",
                        Brand = "Audi",
                        CountryOfOrigin = "Niemcy",
                        DateOfProduction = new DateTime(2018, 01, 01),
                        Mileage = "190000",
                        Color = "Czarny",
                        CarBodyId = 1,
                        CategoryId = 4,
                        EngineTypeId = 1
                    }
                },
                new Auction()
                {
                    AuctionTittle = "Bmw x5!! Promocja",
                    AuctionDate = DateTime.Now,
                    Price = 90000,
                    Car = new Car()
                    {
                        Model = "X5",
                        Brand = "BMW",
                        CountryOfOrigin = "Niemcy",
                        DateOfProduction = new DateTime(2015, 10, 15),
                        Mileage = "200000",
                        Color = "Biały",
                        CarBodyId = 3,
                        CategoryId = 1,
                        EngineTypeId = 2
                    }
                },
                new Auction()
                {
                    AuctionTittle = "Najlepszy samochód dostawczy!!! Fiat Ducato!",
                    AuctionDate = DateTime.Now,
                    Price = 40000,
                    Car =  new Car()
                        { 
                            Model = "Ducato", 
                            Brand = "Fiat",
                            CountryOfOrigin = "Polska",
                            DateOfProduction = new DateTime(2006, 07, 30),
                            Mileage = "500000",
                            Color = "Biały",
                            CarBodyId = 5,
                            CategoryId = 2,
                            EngineTypeId = 1
                        },
                    },
                new Auction()
                {
                    AuctionTittle = "Opel astra bardzo dobry samochód osobowy",
                    AuctionDate = DateTime.Now,
                    Price = 15000,
                    Car = new Car()
                    {
                        Model = "Astra",
                        Brand = "Opel",
                        CountryOfOrigin = "Niemcy",
                        DateOfProduction = new DateTime(2010, 06, 20),
                        Mileage = "63000",
                        Color = "Czerwony",
                        CarBodyId = 1,
                        CategoryId = 1,
                        EngineTypeId = 3
                    }
                },
            };
            return auctions;
        }

        private IEnumerable<CarBody> GetCarBodiesToSeed()
        {
            var carBodies = new List<CarBody>()
            {
                new CarBody() { NameOfCarBody = "Kombi" },
                new CarBody() { NameOfCarBody = "Sedan" },
                new CarBody() { NameOfCarBody = "SUV" },
                new CarBody() { NameOfCarBody = "Kabriolet" },
                new CarBody() { NameOfCarBody = "Bus" }
            };

            return carBodies;
        }

        private IEnumerable<Category> GetCategoriesToSeed()
        {
            var categories = new List<Category>()
            {
                new Category() { CategoryName = "Osobowy" },
                new Category() { CategoryName = "Dostawczy" },
                new Category() { CategoryName = "Ciężarowy" },
                new Category() { CategoryName = "Sportowy" },
            };
            return categories;
        }

        private IEnumerable<EngineType> GetEngineTypesToSeed()
        {
            var engines = new List<EngineType>()
            {
                new EngineType() { EngineName = "Diesel" },
                new EngineType() { EngineName = "Benzyna" },
                new EngineType() { EngineName = "Benzyna + LPG" }
            };

            return engines;
        }
        }
    }
}
