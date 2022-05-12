using CarAuctionMVC.Application.Entities.Base;

namespace CarAuctionMVC.Application.Entities
{
    public class EngineType : BaseEntity
    {
        public string? EngineName { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
