using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Models
{
    public class RewardPoints
    {
        public int PointId { get; set; }
        public int Points { get; set; }
        public int ItemId { get; set; }
        public ItemViewModel Item { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
