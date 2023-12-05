using CatalogEventBus;
using OfferCatalog.API.Infrastructure.IntegrationEvents.Events;
using OfferCatalog.API.Models;

namespace OfferCatalog.API.Services
{
    public class ItemPriceChangeService : IItemPriceChangeService
    {
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;
        private readonly ILogger<ItemPriceChangeService> _logger;

        public ItemPriceChangeService(IRabbitMQPersistantConnection rabbitMQPersistantConnection, ILogger<ItemPriceChangeService> logger)
        {
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
            _logger = logger;
        }

        public Task<string> PriceChange(ItemPriceChange item)
        {
            try
            {
                var priceChange = new ItemPriceChangeIntegrationEvent(item);
                string eventMsgQueueName = "price_change";
                _rabbitMQPersistantConnection.Publish(eventMsgQueueName, priceChange);
                _logger.LogInformation("Price change has been submitted.");
                return Task.FromResult("success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update price in other systems.");
                throw new Exception($"Failed to update price in other systems.", ex);
            }
        }
    }
}
