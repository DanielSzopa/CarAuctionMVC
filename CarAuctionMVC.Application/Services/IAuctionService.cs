﻿using CarAuctionMVC.Application.Dtos;

namespace CarAuctionMVC.Application.Services;

public interface IAuctionService
{
    Task<ListOfAuctionDto> GetListOfAuctions();
    Task<NewAuctionDto> GetNewAuctionDtoDtoForEdit(int id);
    Task<AuctionDetailsDto> GetAuctionDetailsById(int id);
    Task CreateNewAuction(NewAuctionDto auctionDto);
    Task EditAuction(NewAuctionDto auctionDto);
    Task<NewAuctionDto> GetNewAuctionDtoBeforeCreate();
    Task DeleteAuction(int id);
}