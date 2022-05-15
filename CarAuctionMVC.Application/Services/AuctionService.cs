using CarAuctionMVC.Application.Context;
using CarAuctionMVC.Application.Dtos;
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

        public async Task<ListOfAuctionDto> GetListOfAuctionDto()
        {
            var auctions = await GetAuctions();
            var listOfAuctions = new ListOfAuctionDto() { Auctions = auctions };
            return listOfAuctions;
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
