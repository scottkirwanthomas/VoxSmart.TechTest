using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Models;

namespace VoxSmart.TechTest.FinancialEntities.Interfaces
{
    public interface IExtractionStrategy
    {
        bool IsEnabled { get; }

        List<string> ExtractEntity(List<MarketItem> items);
    }
}
