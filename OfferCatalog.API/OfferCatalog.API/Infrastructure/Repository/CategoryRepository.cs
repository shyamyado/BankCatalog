using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDBContext _dBContext;

        public CategoryRepository(CatalogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<string> AddCategory(Category category)
        {
            _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();
            return "Added";
        }

        public async Task<string> AddDepartment(DepartmentNew department)
        {
            Department dept = new Department
            {
                Name = department.Name,
                Description = department.Description
            };
            await _dBContext.Departments.AddAsync(dept);
            await _dBContext.SaveChangesAsync();
            return "Added";
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var res = await _dBContext.Categories.ToListAsync();
            return res;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var res = await _dBContext.Departments.ToListAsync();
            return res;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var res = await _dBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var res = await _dBContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public Task<string> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
