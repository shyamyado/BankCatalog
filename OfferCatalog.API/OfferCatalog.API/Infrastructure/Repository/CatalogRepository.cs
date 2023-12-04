using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Infrastructure.Repository
{

    public class CatalogRepository : ICatalogRepository
    {

        public readonly CatalogDBContext _dbContext;


        public CatalogRepository(CatalogDBContext catalogDBContext)
        {
            _dbContext = catalogDBContext;
        }

        public async Task<List<ItemViewModel>> GetAllItems(int page, int pageSize)
        {
            int itemsToSkip = (page - 1) * pageSize;

            var res = await _dbContext.Items
                        .OrderBy(item => item.Id)
                        .Skip(itemsToSkip)
                        .Take(pageSize)
                        .ToListAsync();
            return res;
        }

        public async Task<(ItemViewModel, string)> AddItem(ItemCreate item)
        {
            ItemViewModel new_item = new ItemViewModel
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
            try
            {
                _dbContext.Items.Add(new_item);
                await _dbContext.SaveChangesAsync();
                return (new_item, null);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
                {
                    Console.WriteLine("Foreign key constraint violation. CategoryId does not exist.");
                    return (null, "CategoryId does not exist");
                }
                else
                {
                    Console.WriteLine($"DbUpdateException: {ex.Message}");
                    return (null, ex.Message);
                }
            }
        }

        public async Task<ItemViewModel> GetItemById(int id)
        {
            var res = await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        public async Task<ItemViewModel> UpdateItem(ItemUpdate item)
        {
            var itemToUpdate = _dbContext.Items.FirstOrDefault(x => x.Id == item.Id);
            if (itemToUpdate != null)
            {
                _dbContext.Entry(itemToUpdate).CurrentValues.SetValues(item);
                //_dbContext.Entry(itemToUpdate).State = EntityState.Modified;
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
