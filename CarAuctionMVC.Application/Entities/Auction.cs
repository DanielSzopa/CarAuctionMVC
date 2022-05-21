using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class Auction : BaseEntity
    {
        public string? AuctionTittle { get; set; }
        public DateTime? AuctionDate { get; set; }
        public double BuyNowPrice { get; set; }
        public double StartAuctionPrice { get; set; }
        public double AuctionPrice { get; set; }
        public Car? Car { get; set; }
    }
}
