using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;

namespace VoxSmart.TechTest.FinancialEntities.Mappers
{
    public class MarketItemMapper : IMarketItemMapper
    {
        public MarketItem ToItem(SyndicationItem from)
        {
            return new MarketItem
            {
                Title = from.Title.Text,
                Description = from.Summary.Text,
                PubDate = from.PublishDate.DateTime
            };
        }
    }
}
