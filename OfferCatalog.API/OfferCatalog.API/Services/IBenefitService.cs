using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public interface IBenefitService
    {
        public void AddBenefit(Benefit benefit);
        public void UpdateBenefit(int benefitId);
        public Task<List<Benefit>> GetBenefitList();
    }
}
