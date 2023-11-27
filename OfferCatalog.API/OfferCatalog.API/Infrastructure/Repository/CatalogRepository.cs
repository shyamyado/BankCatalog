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
                ShortDescription = item.ShortDescription,
                JoiningFees = item.JoiningFees,
                AnnualFees = item.AnnualFees,
                CategoryId = item.CategoryId,
                IsActive = item.IsActive,
                IsPhysical = item.IsPhysical,
                Image = item.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _dbContext.Items.Add(new_item);
            await _dbContext.SaveChangesAsync();
            return new_item;
        }

        public async Task<Item> GetItemById(int id)
        {
            var res = await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        public async Task<Item> UpdateItem(ItemUpdate item)
        {
            var itemToUpdate = await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (itemToUpdate != null)
            {
                _dbContext.Entry(itemToUpdate).CurrentValues.SetValues(item);
                await _dbContext.SaveChangesAsync();
            }
            var res = await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            return res;
        }
        public void UpDateItemIsActive(int ItemId, int status)
        {
            _dbContext.Items.FirstOrDefault(x => x.Id == ItemId);
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

        


    }
}
