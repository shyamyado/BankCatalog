using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Infrastructure.Repository
{
    public class RewardsAndBenefitsRepository : IRewardsAndBenefitsRepository
    {
        private readonly CatalogDBContext _dbContext;

        public void AddBenefit(Benefit benefit)
        {
            throw new NotImplementedException();
        }

        public void AddRewardPoints(RewardPoints rewardPoints)
        {
            throw new NotImplementedException();
        }

        public List<Benefit> GetAllBenefits()
        {
            throw new NotImplementedException();
        }

        public List<RewardPoints> GetAllRewardPoints()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBenefit(Benefit benefit)
        {
            throw new NotImplementedException();
        }
    }
}
