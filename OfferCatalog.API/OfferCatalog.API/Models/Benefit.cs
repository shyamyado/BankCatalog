namespace OfferCatalog.API.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string Benefits { get; set; }
    }
}
