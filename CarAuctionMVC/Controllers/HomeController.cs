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
            var auctions = await _auctionService.GetListOfAuctionDto();
            return await Task.Run(() => View(auctions));
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}