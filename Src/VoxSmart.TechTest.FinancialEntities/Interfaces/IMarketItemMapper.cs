using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Models;

namespace VoxSmart.TechTest.FinancialEntities.Interfaces
{
    public interface IMarketItemMapper
    {
        MarketItem ToItem(SyndicationItem from);
    }
}
