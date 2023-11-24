using Microsoft.Extensions.Options;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Utilities;

namespace VoxSmart.TechTest.FinancialEntities.Strategies
{
    public class AgriculturalCommoditiesStrategy : IExtractionStrategy
    {
        public AgriculturalCommoditiesStrategy(IOptions<ExtractionConfiguration> options)
        {
            IsEnabled = options.Value.EnabledStrategies.Contains(nameof(AgriculturalCommoditiesStrategy));
        }
        public bool IsEnabled { get; }

        public List<string> ExtractEntity(List<MarketItem> items)
        {
            var results = new List<string>();
            StaticData.AgriculturalCommodities.ForEach((x) =>
            {
                if (items.Any(y => y.Title.Contains(x, StringComparison.InvariantCultureIgnoreCase) || y.Description.Contains(x, StringComparison.InvariantCultureIgnoreCase)))
                {
                    results.Add(x);
                }
            });
            return results;
        }
    }
}
