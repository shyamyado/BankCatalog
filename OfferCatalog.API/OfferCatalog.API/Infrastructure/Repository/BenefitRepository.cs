using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public class BenefitRepository : IBenefitRepository
    {
        private readonly CatalogDBContext _dbContext;

        public BenefitRepository(CatalogDBContext catalogDBContext)
        {
                _dbContext = catalogDBContext;
        }
        public void AddBenefit(Benefit benefit)
        {
            _dbContext.Benefits.Add(benefit);
            _dbContext.SaveChanges();
        }

        public async Task<List<Benefit>> GetBenefitList()
        {
            return await _dbContext.Benefits.ToListAsync();
        }

        public void UpdateBenefit(int benefitId)
        {
            throw new NotImplementedException();
        }
    }
}
