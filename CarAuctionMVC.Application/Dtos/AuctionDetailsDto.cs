namespace CarAuctionMVC.Application.Dtos
{
    public class AuctionDetailsDto
    {
        public string? AuctionTittle { get; set; }
        public DateTime? AuctionDate { get; set; }
        public double Price { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? CountryOfOrigin { get; set; }
        public string? DateOfProduction { get; set; }
        public string? Mileage { get; set; }
        public string? Color { get; set; }
        public string? NameOfCarBody { get; set; }
        public string? CategoryName { get; set; }
        public string? EngineName { get; set; }
    }
}
