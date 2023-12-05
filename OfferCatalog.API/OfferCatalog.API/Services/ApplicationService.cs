using CatalogEventBus;
using OfferCatalog.API.Infrastructure.IntegrationEvents.Events;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;

        public ApplicationService(IRabbitMQPersistantConnection rabbitMQPersistantConnection)
        {
                _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
        }
        public Task<string> ApplyCard(ApplicationForm form)
        {
            var newApplication = new ApplyCardIntegrationEvent(form);
            _rabbitMQPersistantConnection.Publish(newApplication);
            return Task.FromResult("success");
        }
    }
}
