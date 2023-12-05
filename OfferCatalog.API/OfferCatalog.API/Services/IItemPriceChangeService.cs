using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public interface IItemPriceChangeService
    {
        public Task<string> PriceChange(ItemPriceChange item);
    }
}
