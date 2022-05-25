using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Dtos;
using CarAuctionMVC.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarAuctionMVC.Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly CarAuctionMVCDbContext _dbContext;
        private readonly ILogger<AuctionService> _logger;

        public AuctionService(CarAuctionMVCDbContext dbContext, ILogger<AuctionService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ListOfAuctionDto> GetListOfAuctions(string searchString)
        {
            if (searchString is null)
                searchString = string.Empty;

            var auctions = await GetAuctions(searchString);
            var listOfAuctions = new ListOfAuctionDto() { Auctions = auctions };
            return listOfAuctions;
        }

        public async Task<AuctionDetailsDto> GetAuctionDetailsById(int id)
        {
            try
            {
                var auctionDetails = await _dbContext.Auctions
                    .Include(a => a.Car)
                    .ThenInclude(c => c.CarBody)
                    .Include(a => a.Car)
                    .ThenInclude(c => c.EngineType)
                    .Include(a => a.Car)
                    .ThenInclude(c => c.Category)
                    .Where(a => a.Id == id)
                    .Select(a => new AuctionDetailsDto()
                    {
                        Id = a.Id,
                        AuctionTittle = a.AuctionTittle,
                        AuctionDate = a.AuctionDate,
                        BuyNowPrice = a.BuyNowPrice,
                        StartAuctionPrice = a.StartAuctionPrice,
                        AuctionPrice = a.AuctionPrice,
                        Model = a.Car.Model,
                        Brand = a.Car.Brand,
                        CountryOfOrigin = a.Car.CountryOfOrigin,
                        DateOfProduction = a.Car.DateOfProduction.Value.Year.ToString(),
                        Mileage = a.Car.Mileage,
                        Color = a.Car.Color,
                        NameOfCarBody = a.Car.CarBody.NameOfCarBody,
                        CategoryName = a.Car.Category.CategoryName,
                        EngineName = a.Car.EngineType.EngineName
                    }).FirstOrDefaultAsync();

                auctionDetails.AuctionPrice =
                    GetAuctionPriceForDetail(auctionDetails.StartAuctionPrice, auctionDetails.AuctionPrice);
                
                return auctionDetails;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with read auction details {e.ToString()}");
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

        public async Task<NewAuctionDto> GetNewAuctionDtoDtoForEdit(int id)
        {
            try
            {
                var newAuctionDto = await _dbContext.Auctions
                    .Include(a => a.Car)
                    .Where(a => a.Id == id)
                    .Select(a => new NewAuctionDto()
                    {
                        Id = a.Id,
                        AuctionTittle = a.AuctionTittle,
                        AuctionDate = a.AuctionDate,
                        BuyNowPrice = a.BuyNowPrice,
                        StartAuctionPrice = a.StartAuctionPrice,
                        Model = a.Car.Model,
                        Brand = a.Car.Brand,
                        CountryOfOrigin = a.Car.CountryOfOrigin,
                        DateOfProduction = a.Car.DateOfProduction,
                        Mileage = a.Car.Mileage,
                        Color = a.Car.Color,
                        CarBodyId = a.Car.CarBodyId,
                        CategoryId = a.Car.CategoryId,
                        EngineTypeId = a.Car.EngineTypeId
                    }).FirstOrDefaultAsync();

                newAuctionDto.CarBodies = await GetCarBodies();
                newAuctionDto.Categories = await GetCategories();
                newAuctionDto.Engines = await GetEngines();

                return newAuctionDto;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with read auction details before create{e.ToString()}");
                throw;
            }
        }

        public async Task<int> CreateNewAuction(NewAuctionDto auctionDto)
        {
            var auction = MapNewAuctionDtoToAuctionEntity(auctionDto);
            try
            {
                await _dbContext.Auctions.AddAsync(auction);
                await _dbContext.SaveChangesAsync();
                return auction.Id;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with create new auction {e.ToString()}");
                throw;
            }
        }

        public async Task<int> EditAuction(NewAuctionDto auctionDto)
        {
            try
            {
                var auction = await _dbContext.Auctions
                    .Include(a => a.Car)
                    .FirstOrDefaultAsync(a => a.Id == auctionDto.Id);

                if (auction is null)
                    throw new Exception("auction is null");

                auction.AuctionTittle = auctionDto.AuctionTittle;
                auction.BuyNowPrice = auctionDto.BuyNowPrice;
                auction.StartAuctionPrice = auctionDto.StartAuctionPrice;
                auction.Car.Model = auctionDto.Model;
                auction.Car.Brand = auctionDto.Brand;
                auction.Car.CountryOfOrigin = auctionDto.CountryOfOrigin;
                auction.Car.DateOfProduction = auctionDto.DateOfProduction;
                auction.Car.Mileage = auctionDto.Mileage;
                auction.Car.Color = auctionDto.Color;
                auction.Car.CarBodyId = auctionDto.CarBodyId;
                auction.Car.CategoryId = auctionDto.CategoryId;
                auction.Car.EngineTypeId = auctionDto.EngineTypeId;

                await _dbContext.SaveChangesAsync();
                return auction.Id;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with edit auction {e.ToString()}");
                throw;
            }
        }

        public async Task DeleteAuction(int id)
        {
            try
            {
                var auction = await _dbContext.Auctions.FirstOrDefaultAsync(a => a.Id == id);
                if (auction != null)
                {
                   _dbContext.Auctions.Remove(auction);
                   await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with delete auction id: {id} Exception: {e.ToString()}");
                throw;
            }
        }

        public async Task BidAuction(int id, double bidPrice)
        {
            var oldPrices = await _dbContext.Auctions.Where(a => a.Id == id)
                .Select(a => new
                {
                    StartAuctionPrice = a.StartAuctionPrice,
                    AuctionPrice = a.AuctionPrice
                })
                .FirstOrDefaultAsync();

            double oldPrice = GetAuctionPriceForDetail(oldPrices.StartAuctionPrice, oldPrices.AuctionPrice);

            if (oldPrice < bidPrice)
            {
                var auction = await _dbContext.Auctions
                    .FirstOrDefaultAsync(a => a.Id == id);

                auction.AuctionPrice = bidPrice;
                await _dbContext.SaveChangesAsync();
            }
        }

        private double GetAuctionPriceForDetail(double startPrice, double auctionPrice)
        {
            if (auctionPrice >= startPrice)
                return auctionPrice;
            else
                return startPrice;
        }
        private Auction MapNewAuctionDtoToAuctionEntity(NewAuctionDto newAuctionDto)
        {
            var auction = new Auction()
            {
                AuctionDate = DateTime.Now,
                AuctionTittle = newAuctionDto.AuctionTittle,
                BuyNowPrice = newAuctionDto.BuyNowPrice,
                StartAuctionPrice = newAuctionDto.StartAuctionPrice,
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
                _logger.LogInformation($"Problem with get car bodies {e.ToString()}");
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
                _logger.LogInformation($"Problem with get car categories {e.ToString()}");
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
                _logger.LogInformation($"Problem with get car engines {e.ToString()}");
                throw;
            }
        }
        private async Task<List<AuctionDto>> GetAuctions(string searchString)
        {
            try
            {
                var auctions = await _dbContext.Cars
                    .Include(c => c.Auction)
                    .Where(c => (searchString != "") && c.Auction.AuctionTittle.ToLower().Contains(searchString.ToLower())
                    || c.Model.ToLower().Contains(searchString.ToLower()) || c.Brand.ToLower().Contains(searchString.ToLower()))
                    .Select(c => new AuctionDto
                    {
                        Id = c.Auction.Id,
                        Title = c.Auction.AuctionTittle,
                        Brand = c.Brand,
                        Model = c.Model,
                        ProductionYear = c.DateOfProduction.Value.Year.ToString(),
                        BuyNowPrice = c.Auction.BuyNowPrice,
                        StartAuctionPrice = c.Auction.StartAuctionPrice,
                        AuctionPrice = c.Auction.AuctionPrice,
                    }).ToListAsync();

                foreach (var auctionDto in auctions)
                {
                    auctionDto.AuctionPrice =
                        GetAuctionPriceForDetail(auctionDto.StartAuctionPrice, auctionDto.AuctionPrice);
                }

                return auctions;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get auctions {e.ToString()}");
                throw;
            }
        }
    }
}
