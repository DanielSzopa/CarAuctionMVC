using CarAuctionMVC.Application.Dtos;
using CarAuctionMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuctionService _auctionService;

        public HomeController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var auctions = await _auctionService.GetListOfAuctions(searchString);
            return await Task.Run(() => View(auctions));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _auctionService.GetNewAuctionDtoBeforeCreate();
            return await Task.Run(() => View(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewAuctionDto auctionDto)
        {
            var auctionId = await _auctionService.CreateNewAuction(auctionDto);
            return await Task.Run(() => RedirectToAction("Details", new{id = auctionId}));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _auctionService.GetNewAuctionDtoDtoForEdit(id);
            return await Task.Run(() => View(model));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewAuctionDto auctionDto)
        {
            var auctionId =  await _auctionService.EditAuction(auctionDto);
            return await Task.Run(() => RedirectToAction("Details", new { id = auctionId }));
        }

        [HttpPost]
        public async Task<IActionResult> Bid(int id, double auctionPrice)
        {
            await _auctionService.BidAuction(id, auctionPrice);
            return await Task.Run(() => RedirectToAction("Details", new { id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _auctionService.DeleteAuction(id);
            return await Task.Run(() => RedirectToAction("Index"));
        }

        [HttpGet]
        public async Task<IActionResult> BuyNow(int id)
        {
            await _auctionService.DeleteAuction(id);
            return await Task.Run(() => RedirectToAction("Index"));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var auctionDetails = await _auctionService.GetAuctionDetailsById(id);
            return await Task.Run(() => View(auctionDetails));
        }
    }
}