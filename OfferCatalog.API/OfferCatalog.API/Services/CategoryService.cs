using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> AddCategory(CategoryNew category)
        {
            Category category1 = new Category
            {
                CategoryName = category.CategoryName,
                Subcategory = category.Subcategory,
                DepartmentId = category.DepartmentId,
                Type = category.Type,
                IsActive = category.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var res = await _repository.AddCategory(category1);
            return res;
        }

        public async Task<string> AddDepartment(DepartmentNew department)
        {
            var res = await _repository.AddDepartment(department);
            return res;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var res = await _repository.GetAllCategories();
            return res;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var res = await _repository.GetAllDepartments();
            return res;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var res = await _repository.GetCategoryById(id);
            return res;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var res = await _repository.GetDepartmentById(id);
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
