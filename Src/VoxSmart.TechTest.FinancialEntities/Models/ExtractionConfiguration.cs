using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxSmart.TechTest.FinancialEntities.Models
{
    public class ExtractionConfiguration
    {
        public string FeedUrl { get; set; }
        public List<string> EnabledStrategies { get; set; }
    }
}
