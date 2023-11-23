using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IRewardsAndBenefitsRepository
    {
        public void AddRewardPoints(RewardPoints rewardPoints);
        public List<RewardPoints> GetAllRewardPoints();
        public void AddBenefit(Benefit benefit);
        public void UpdateBenefit(Benefit benefit);
        public List<Benefit> GetAllBenefits();

        public void Save();
    }
}
