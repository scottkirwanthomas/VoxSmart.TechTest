using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Utilities;

namespace VoxSmart.TechTest.FinancialEntities.Strategies
{
    public class CurrencyCodesStrategy : IExtractionStrategy
    {
        public CurrencyCodesStrategy(IOptions<ExtractionConfiguration> options)
        {
            IsEnabled = options.Value.EnabledStrategies.Contains(nameof(CurrencyCodesStrategy));
            ;
        }
        public bool IsEnabled { get; }

        public List<string> ExtractEntity(List<MarketItem> items)
        {
            var results = new List<string>();
            StaticData.CurrencyCodes.ForEach((x) =>
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
