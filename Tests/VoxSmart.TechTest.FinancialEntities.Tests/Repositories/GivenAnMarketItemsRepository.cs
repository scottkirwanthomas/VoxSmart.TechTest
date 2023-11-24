using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Mappers;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Repositories;

namespace VoxSmart.TechTest.FinancialEntities.Tests.Repositories
{
    [TestFixture]
    public class GivenAnMarketItemsRepository
    {
        private IMarketItemsRepository _sut;
        private Mock<IOptions<ExtractionConfiguration>> _mockOptions;
        private Mock<IMarketItemMapper> _mockMapper;
        private ExtractionConfiguration _configuration;
        [SetUp]
        public void SetUp()
        {
            _configuration = new ExtractionConfiguration();

            _mockOptions = new Mock<IOptions<ExtractionConfiguration>>();
            _mockOptions.Setup(x => x.Value).Returns(_configuration).Verifiable();
            _mockMapper = new Mock<IMarketItemMapper>();

            _sut = new MarketItemsRepository(_mockOptions.Object, _mockMapper.Object);
        }

        [Test]
        public void WhenGetMarketItemsIsCalled_WithAValidFeedUrl_ThenAListOfMarketItemsIsReturned()
        {
            _configuration.FeedUrl = "https://feeds.a.dj.com/rss/RSSMarketsMain.xml";
            _mockMapper.Setup(x => x.ToItem(It.IsAny<SyndicationItem>())).Returns(new MarketItem());

            var results = _sut.GetMarketItems();

            using (new AssertionScope())
            {
                results.Should().BeOfType<List<MarketItem>>();
                results.Should().HaveCountGreaterThan(0);
                _mockOptions.Verify(x => x.Value, Times.Once());
                _mockMapper.Verify(x => x.ToItem(It.IsAny<SyndicationItem>()), Times.AtLeastOnce);
            }
        }

        [Test]
        public void WhenGetMarketItemsIsCalled_WithAnEmptyFeedUrl_ThenAnExceptionIsThrown()
        {
            _configuration.FeedUrl = "";
            _mockMapper.Setup(x => x.ToItem(It.IsAny<SyndicationItem>())).Returns(new MarketItem());

            Action act = () => _sut.GetMarketItems();

            act.Should().Throw<ArgumentException>();

        }

        [Test]
        public void WhenGetMarketItemsIsCalled_WithAnInvalidFeedUrl_ThenAnExceptionIsThrown()
        {
            _configuration.FeedUrl = "something";
            _mockMapper.Setup(x => x.ToItem(It.IsAny<SyndicationItem>())).Returns(new MarketItem());

            Action act = () => _sut.GetMarketItems();

            act.Should().Throw<FileNotFoundException>();

        }
    }
}
