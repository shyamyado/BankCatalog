using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{

    public class CatalogRepository : ICatalogRepository
    {

        public readonly CatalogDBContext _dbContext;

        public CatalogRepository(CatalogDBContext catalogDBContext)
        {
            _dbContext = catalogDBContext;
        }

        public async Task<List<Item>> GetAllItems()
        {
            var res = await _dbContext.Items.ToListAsync();
            return res;
        }

        public async Task<Item> AddItem(ItemNew item)
        {
            Item new_item = new Item
            {
                Name = item.Name,
                Description = item.Description,
                JoiningFees = item.JoiningFees,

                Category = item.Category,
                SubCategory = item.SubCategory,
                Type = item.Type,
                DepartmentId = item.DepartmentId,
                IsActive = item.IsActive,
                IsPhysical = item.IsPhysical,
                ImageUrl = item.ImageUrl,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _dbContext.Items.Add(new_item);
            return new_item;
        }

        public async Task<Item> GetItemById(int id)
        {
            var res = await _dbContext.Items.FirstOrDefaultAsync(x => x.ItemId == id);
            return res;
        }
        public async Task<Item> UpdateItem(Item item)
        {
            Item itemToUpdate = await _dbContext.Items.FirstOrDefaultAsync(x => x.ItemId == item.ItemId);
            if (itemToUpdate != null)
            {
                _dbContext.Entry(itemToUpdate).CurrentValues.SetValues(item);
            }
            _dbContext.SaveChanges();
            return item;
        }
        public void UpDateItemIsActive(int ItemId, int status)
        {
            _dbContext.Items.FirstOrDefault(x => x.ItemId == ItemId);
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void AddNewDepartment(Department newDepartment)
        {
            _dbContext.Departments.Add(newDepartment);
        }

        public void UpdatePrice(Price price)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
