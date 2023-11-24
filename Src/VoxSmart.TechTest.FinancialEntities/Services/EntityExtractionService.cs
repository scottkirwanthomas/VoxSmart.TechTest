using Microsoft.Extensions.Logging;
using VoxSmart.TechTest.FinancialEntities.Interfaces;

namespace VoxSmart.TechTest.FinancialEntities.Services
{
    public class EntityExtractionService : IEntityExtractionService
    {
        private readonly IMarketItemsRepository _marketItemsRepository;
        private readonly List<IExtractionStrategy> _extractionStrategies;
        private readonly ILogger<EntityExtractionService> _logger;
        public EntityExtractionService(IMarketItemsRepository marketItemsRepository
            , IEnumerable<IExtractionStrategy> extractionStrategies
            , ILogger<EntityExtractionService> logger) 
        { 
            _marketItemsRepository = marketItemsRepository;
            _extractionStrategies = extractionStrategies.ToList(); 
            _logger = logger;
        }

        public List<string> ExtractEntities()
        {
            var results = new List<string>();
            try
            {
                var enabledStrategies = _extractionStrategies.Where(x => x.IsEnabled).ToList();
                if (enabledStrategies.Any())
                {
                    var items = _marketItemsRepository.GetMarketItems();
                    enabledStrategies.ForEach(x =>
                    {
                        results.AddRange(x.ExtractEntity(items).Distinct());
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Extraction failed", ex);
            }
            return results.Distinct().ToList();
        }
    }
}
