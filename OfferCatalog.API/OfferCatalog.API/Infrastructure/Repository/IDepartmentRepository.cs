using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department department);
        public void Update(Department department);
        public Department GetDepartmentById(int id);
        public Department GetDepartmentByName(String department);

    }
}
