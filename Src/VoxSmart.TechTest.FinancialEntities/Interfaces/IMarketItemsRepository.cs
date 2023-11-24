using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Models;

namespace VoxSmart.TechTest.FinancialEntities.Interfaces
{
    public interface IMarketItemsRepository
    {
        List<MarketItem> GetMarketItems();
    }
}
