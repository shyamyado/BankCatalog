using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface ICatalogRepository
    {
        public Task<Item> AddItem(ItemNew item);
        public Task<List<Item>> GetAllItems();
        public Task<Item> GetItemById(int id);
        public Task<Item> UpdateItem(ItemUpdate item);
        public void UpDateItemIsActive(int ItemId, int status);
        public void UpdatePrice(Price price);
        public void UpdateDepartment(Department department);
    }
}
