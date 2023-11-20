using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IPriceRepository
    {
        public void Add(Price price);
        public void Update(Price price);
        public void UpdateCreditLimit(decimal creditLimit);

    }
}
