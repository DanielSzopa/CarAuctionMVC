﻿using CarAuctionMVC.Application.Dtos;
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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
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