using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public interface IApplicationService
    {
        public Task<string> ApplyCard(ApplicationForm form);
    }
}
