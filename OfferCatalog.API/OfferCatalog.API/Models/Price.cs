namespace OfferCatalog.API.Models
{
    public class Price
    {
        public int PriceId { get; set; }
        public decimal DefaultCreditLimit { get; set; }
        public decimal AnnualFees { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
