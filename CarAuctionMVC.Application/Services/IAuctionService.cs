using CarAuctionMVC.Application.Dtos;

namespace CarAuctionMVC.Application.Services;

public interface IAuctionService
{
    Task<ListOfAuctionDto> GetListOfAuctions();
    Task CreateNewAuction(NewAuctionDto auctionDto);
    Task<NewAuctionDto> GetNewAuctionDtoBeforeCreate();
}