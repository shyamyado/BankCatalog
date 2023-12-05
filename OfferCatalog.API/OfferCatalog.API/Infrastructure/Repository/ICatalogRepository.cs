using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface ICatalogRepository
    {
        public Task<ItemViewModel> AddItem(ItemCreate item);
        public Task<List<ItemViewModel>> GetAllItems(int page, int pageSize);
        public Task<ItemViewModel> GetItemById(int id);
        public Task<ItemViewModel> UpdateItem(ItemUpdate item);
        public void UpDateItemIsActive(int ItemId, int status);
        public void UpdatePrice(Price price);
        public void UpdateDepartment(Department department);
    }
}
