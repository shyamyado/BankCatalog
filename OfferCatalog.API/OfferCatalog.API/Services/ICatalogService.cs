using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Services
{
    public interface ICatalogService
    {
        public Task<ItemViewModel> AddItem(ItemCreate item);
        public Task<ItemViewModel> GetItemById(int id);
        public Task<List<ItemViewModel>> GetAllItems(int page, int pageSize);
        public Task<ItemViewModel> UpdateItem(ItemUpdate item);

    }
}
