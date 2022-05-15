using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Dtos;
using CarAuctionMVC.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAuctionMVC.Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly CarAuctionMVCDbContext _dbContext;

        public AuctionService(CarAuctionMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ListOfAuctionDto> GetListOfAuctions()
        {
            var auctions = await GetAuctions();
            var listOfAuctions = new ListOfAuctionDto() { Auctions = auctions };
            return listOfAuctions;
        }

        public async Task CreateNewAuction(NewAuctionDto auctionDto)
        {
            var auction = MapNewAuctionDtoToAuctionEntity(auctionDto);
            try
            {
                await _dbContext.Auctions.AddAsync(auction);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<NewAuctionDto> GetNewAuctionDtoBeforeCreate()
        {
            var model = new NewAuctionDto()
            {
                CarBodies = await GetCarBodies(),
                Categories = await GetCategories(),
                Engines = await GetEngines()
            };
            return model;
        }

        private Auction MapNewAuctionDtoToAuctionEntity(NewAuctionDto newAuctionDto)
        {
            var auction = new Auction()
            {
                AuctionDate = DateTime.Now,
                AuctionTittle = newAuctionDto.AuctionTittle,
                Price = newAuctionDto.Price,
                Car = new Car()
                {
                    Model = newAuctionDto.Model,
                    Brand = newAuctionDto.Brand,
                    CountryOfOrigin = newAuctionDto.CountryOfOrigin,
                    DateOfProduction = newAuctionDto.DateOfProduction,
                    Mileage = newAuctionDto.Mileage,
                    Color = newAuctionDto.Color,
                    CarBodyId = newAuctionDto.CarBodyId,
                    CategoryId = newAuctionDto.CategoryId,
                    EngineTypeId = newAuctionDto.EngineTypeId
                }
            };
            return auction;
        }

        private async Task<List<CarBody>> GetCarBodies()
        {
            try
            {
                var carBodies = await _dbContext.CarBodies.ToListAsync();
                return carBodies;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<List<Category>> GetCategories()
        {
            try
            {
                var categories = await _dbContext.Categories.ToListAsync();
                return categories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<List<EngineType>> GetEngines()
        {
            try
            {
                var engines = await _dbContext.EngineTypes.ToListAsync();
                return engines;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private async Task<List<AuctionDto>> GetAuctions()
        {
            try
            {
                var auctions = await _dbContext.Cars
                    .Include(c => c.Auction)
                    .Select(c => new AuctionDto
                    {
                        Id = c.Auction.Id,
                        Title = c.Auction.AuctionTittle,
                        Brand = c.Brand,
                        Model = c.Model,
                        ProductionYear = c.DateOfProduction.Value.Year.ToString(),
                        Price = c.Auction.Price
                    }).ToListAsync();

                return auctions;
            }
            catch (Exception e)
            {
                return new List<AuctionDto>();
            }
        }
    }
}
