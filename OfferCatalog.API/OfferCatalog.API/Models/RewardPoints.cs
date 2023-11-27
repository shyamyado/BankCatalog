namespace OfferCatalog.API.Models
{
    public class RewardPoints
    {
        public int PointId { get; set; }
        public int Points { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
