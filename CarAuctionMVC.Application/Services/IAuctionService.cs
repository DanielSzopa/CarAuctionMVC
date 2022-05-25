using CarAuctionMVC.Application.Dtos;

namespace CarAuctionMVC.Application.Services;

public interface IAuctionService
{
    Task<ListOfAuctionDto> GetListOfAuctions(string searchString);
    Task<AuctionDetailsDto> GetAuctionDetailsById(int id);
    Task<NewAuctionDto> GetNewAuctionDtoBeforeCreate();
    Task<NewAuctionDto> GetNewAuctionDtoDtoForEdit(int id);
    Task<int> CreateNewAuction(NewAuctionDto auctionDto);
    Task<int> EditAuction(NewAuctionDto auctionDto);
    Task DeleteAuction(int id);
    Task BidAuction(int id, double bidPrice);
}