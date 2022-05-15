using CarAuctionMVC.Application.Dtos;

namespace CarAuctionMVC.Application.Services;

public interface IAuctionService
{
    Task<ListOfAuctionDto> GetListOfAuctionDto();
}