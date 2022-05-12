using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class Car : BaseEntity
    {
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? CountryOfOrigin { get; set; }
        public DateTime? DateOfProduction { get; set; }
        public string? Mileage { get; set; }
        public string? Color { get; set; }
        public int AuctionId { get; set; }
        public int CarBodyId { get; set; }
        public int CategoryId { get; set; }
        public int EngineTypeId { get; set; }
        public Auction? Auction { get; set; }
        public CarBody? CarBody { get; set; }
        public Category? Category { get; set; }
        public EngineType? EngineType { get; set; }
    }
}
