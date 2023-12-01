using NLog;
using NLog.Targets;
using OfferCatalog.API.Infrastructure.Repository;
using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
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
                _logger.Info($"Retrieved {result.Count} items");
                _logger.Info($"{DateTime.Now} : Shyam : Retrieved {result.Count} items");

                Console.WriteLine($"Retrieved {result.Count} items");
                Console.WriteLine("-------------------");
                Console.WriteLine(fileTarget);
                Console.WriteLine("-----------------------------");
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
