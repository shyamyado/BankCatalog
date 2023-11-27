using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public interface ICategoryService
    {
        public Task<string> AddCategory(CategoryNew category);
        public Task<Category> GetCategoryById(int id);
        public Task<List<Category>> GetAllCategories();
        public Task<string> UpdateCategory(Category category);

        public Task<string> AddDepartment(DepartmentNew department);
        public Task<Department> GetDepartmentById(int id);
        public Task<List<Department>> GetAllDepartments();
        public Task<string> UpdateDepartment(Department department);
    }
}
