using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IBenefitRepository
    {
        public void AddBenefit(Benefit benefit);
        public void UpdateBenefit(int benefitId);
        public Task<List<Benefit>> GetBenefitList();  

    }
}
