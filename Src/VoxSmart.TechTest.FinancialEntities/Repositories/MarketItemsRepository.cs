using Microsoft.Extensions.Options;
using System.ServiceModel.Syndication;
using System.Xml;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;

namespace VoxSmart.TechTest.FinancialEntities.Repositories
{
    public class MarketItemsRepository : IMarketItemsRepository
    {
        private readonly ExtractionConfiguration _config;
        private readonly IMarketItemMapper _marketItemMapper;
        public MarketItemsRepository(IOptions<ExtractionConfiguration> options
            , IMarketItemMapper marketItemMapper)
        {
            _config = options.Value;
            _marketItemMapper = marketItemMapper;
        }
        public List<MarketItem> GetMarketItems()
        {
            var results = new List<MarketItem>();
            using (var reader = XmlReader.Create(_config.FeedUrl))
            {
                var feed = SyndicationFeed.Load(reader);
                feed.Items.ToList().ForEach(x => results.Add(_marketItemMapper.ToItem(x)));
            }
            return results;
        }
    }
}
