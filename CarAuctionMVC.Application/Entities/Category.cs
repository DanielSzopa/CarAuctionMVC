using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
