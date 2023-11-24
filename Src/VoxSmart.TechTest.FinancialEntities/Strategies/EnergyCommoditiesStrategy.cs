﻿using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Utilities;

namespace VoxSmart.TechTest.FinancialEntities.Strategies
{
    public class EnergyCommoditiesStrategy : IExtractionStrategy
    {
         public EnergyCommoditiesStrategy(IOptions<ExtractionConfiguration> options)
        {
            IsEnabled = options.Value.EnabledStrategies.Contains(nameof(EnergyCommoditiesStrategy));
        }
        public bool IsEnabled { get; }

        public List<string> ExtractEntity(List<MarketItem> items)
        {
            var results = new List<string>();
            StaticData.EnergyCommodities.ForEach((x) =>
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
