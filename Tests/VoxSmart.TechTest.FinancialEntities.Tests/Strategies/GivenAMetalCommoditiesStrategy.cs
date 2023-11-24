using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Strategies;

namespace VoxSmart.TechTest.FinancialEntities.Tests.Strategies
{
    [TestFixture]
    public class GivenAnMetalCommoditiesStrategy
    {
        private IExtractionStrategy _sut;
        private Mock<IOptions<ExtractionConfiguration>> _mockOptions;
        private ExtractionConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            _configuration = new ExtractionConfiguration();
            _configuration.EnabledStrategies = new List<string>();
            _mockOptions = new Mock<IOptions<ExtractionConfiguration>>();
            _mockOptions.Setup(x => x.Value).Returns(_configuration).Verifiable();
            _sut = new MetalCommoditiesStrategy(_mockOptions.Object);
        }

        [Test]
        public void WhenExtractEntityIsCalled_WithANullMarketItemList_ThenAnExceptionIsThrown()
        {
            Action act = () => _sut.ExtractEntity(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void WhenExtractEntityIsCalled_WithAValidMarketItemList_AndAMatchIsFound_ThenAPopulatedListIsReturned()
        {
            var marketItems = new List<MarketItem> { new MarketItem {Title="Something going on",  Description = "of all the metals in the world Tin is the most versatile" } };
            var expectedResults = new List<string> { "Tin" };

            var results = _sut.ExtractEntity(marketItems);

            results.Should().HaveCount(1).And.BeOfType<List<string>>().And.BeEquivalentTo(expectedResults);
        }
    }
}