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
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;

        public CatalogService(ICatalogRepository catalogRepository, IRabbitMQPersistantConnection rabbitMQPersistantConnection)
        {
            _catalogRepository = catalogRepository;
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection;
        }

        public async Task<(ItemViewModel, string)> AddItem(ItemCreate item)
        {
            var (res, errorMsg) = await _catalogRepository.AddItem(item);
            return (res, errorMsg);
        }

        public async Task<List<ItemViewModel>> GetAllItems(int page, int pageSize)
        {
            var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
            try
            {

                var result = await _catalogRepository.GetAllItems(page, pageSize);
                _logger.Info($"{DateTime.Now} : Retrieved {result.Count} items");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error getting all items: {ex.Message}");
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
