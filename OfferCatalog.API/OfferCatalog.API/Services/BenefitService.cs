using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public class BenefitService : IBenefitService
    {
        private readonly IBenefitRepository _repository;

        public BenefitService(IBenefitRepository repository)
        {
            _repository = repository;
        }
        public void AddBenefit(Benefit benefit)
        {
            _repository.AddBenefit(benefit);
        }

        public async Task<List<Benefit>> GetBenefitList()
        {
            return await _repository.GetBenefitList();
        }

        public void UpdateBenefit(int benefitId)
        {
            _repository.UpdateBenefit(benefitId);
        }
    }
}
