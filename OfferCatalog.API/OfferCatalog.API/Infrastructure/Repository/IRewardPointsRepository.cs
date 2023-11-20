namespace OfferCatalog.API.Infrastructure.Repository
{
    public interface IRewardPointsRepository
    {
        public void Add(int points);
        public void Update(int points);
    }
}
