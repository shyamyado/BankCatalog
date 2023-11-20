using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IItemRepository
    {
        public void Add(Item item);
        public void Update(Item item);
        public void UpdateActiveStatus(int state);
    }
}
