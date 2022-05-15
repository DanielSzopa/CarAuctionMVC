namespace CarAuctionMVC.Application.Dtos
{
    public class AuctionDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? ProductionYear { get; set; }
        public double Price { get; set; }
    }
}
