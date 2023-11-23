using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public interface ICatalogService
    {
        public Task<Item> AddItem(ItemNew item);
        public Task<Item> GetItemById(int id);
        public Task<List<Item>> GetAllItems();
        public Task<Item> UpdateItem(Item item);

    }
}
