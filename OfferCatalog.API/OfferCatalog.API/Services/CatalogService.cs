using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Item> AddItem(ItemNew item)
        {
            var res= await _catalogRepository.AddItem(item);
            _catalogRepository.Save();
            return res;
        }

        public async Task<List<Item>>  GetAllItems()
        {
            return await _catalogRepository.GetAllItems();
        }
        public async Task<Item> GetItemById(int id)
        {
            var res = await _catalogRepository.GetItemById(id);
            return res;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            _catalogRepository.UpdateItem(item);
            _catalogRepository.Save();
            return item;
        }
    }
}
