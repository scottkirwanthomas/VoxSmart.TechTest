using System.Xml.Serialization;

namespace VoxSmart.TechTest.FinancialEntities.Models
{
    public class MarketItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
    }
}
