using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<(ItemViewModel, string)> AddItem(ItemCreate item)
        {
            var (res, errorMsg) = await _catalogRepository.AddItem(item);
            return (res, errorMsg);
        }

        public async Task<List<ItemViewModel>>  GetAllItems(int page, int pageSize)
        {
            return await _catalogRepository.GetAllItems(page, pageSize);
        }
        public async Task<ItemViewModel> GetItemById(int id)
        {
            var res = await _catalogRepository.GetItemById(id);
            return res;
        }

        public async Task<ItemViewModel> UpdateItem(ItemUpdate item)
        {
            var res = await _catalogRepository.UpdateItem(item);
            return res;
        }

        
    }
}
