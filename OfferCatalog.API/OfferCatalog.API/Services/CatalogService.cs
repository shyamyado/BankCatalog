using CatalogEventBus;
using NLog;
using NLog.Targets;
using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;
using System.Data.SqlTypes;

namespace OfferCatalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly ILogger<CatalogService> _logger;
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;

        public CatalogService(ICatalogRepository catalogRepository, IRabbitMQPersistantConnection rabbitMQPersistantConnection, ILogger<CatalogService> logger)
        {
            _catalogRepository = catalogRepository;
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
            _logger = logger;
        }

        public async Task<ItemViewModel> AddItem(ItemCreate item)
        {
            try
            {
                var result = await _catalogRepository.AddItem(item);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an item.");
                throw new Exception("Failed to add item due to an unexpected error.", ex);
            }
        }

        public async Task<List<ItemViewModel>> GetAllItems(int page, int pageSize)
        {
            var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
            try
            {

                var result = await _catalogRepository.GetAllItems(page, pageSize);
                _logger.LogInformation($"{DateTime.Now} : Retrieved {result.Count} items");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting all items: {ex.Message}");
                throw;
            }
        }
        public async Task<ItemViewModel> GetItemById(int id)
        {
            var res = await _catalogRepository.GetItemById(id);
            return res;
        }

        public async Task<ItemViewModel> UpdateItem(ItemUpdate item)
        {
            var res = await _catalogRepository.UpdateItem(item);
            return res;
        }



    }
}
