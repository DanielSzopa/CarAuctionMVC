using CarAuctionMVC.Application.Entities;

namespace CarAuctionMVC.Application.Dtos
{
    public class NewAuctionDto
    {
        public int Id { get; set; }
        public string? AuctionTittle { get; set; }
        public DateTime? AuctionDate { get; set; }
        public double BuyNowPrice { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? CountryOfOrigin { get; set; }
        public DateTime? DateOfProduction { get; set; }
        public string? Mileage { get; set; }
        public string? Color { get; set; }
        public int CarBodyId { get; set; }
        public int CategoryId { get; set; }
        public int EngineTypeId { get; set; }
        public List<CarBody>? CarBodies { get; set; }
        public List<Category>? Categories { get; set; }
        public List<EngineType>? Engines { get; set; }
    }
}
