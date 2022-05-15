using CarAuctionMVC.Application.Dtos;
using CarAuctionMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuctionService _auctionService;

        public HomeController(ILogger<HomeController> logger, IAuctionService auctionService)
        {
            _logger = logger;
            _auctionService = auctionService;
        }

        public async Task<IActionResult> Index()
        {
            var auctions = await _auctionService.GetListOfAuctions();
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
            await _auctionService.CreateNewAuction(auctionDto);
            return await Task.Run(() => RedirectToAction("Index"));
        }
    }
}