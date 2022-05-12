using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class Auction : BaseEntity
    {
        public string? AuctionTittle { get; set; }
        public DateTime? AuctionDate { get; set; }
        public double Price { get; set; }
        public Car? Car { get; set; }
    }
}
