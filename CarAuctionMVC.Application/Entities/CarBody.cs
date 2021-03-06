using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class CarBody : BaseEntity
    {
        public string? NameOfCarBody { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
