using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Services;

namespace VoxSmart.TechTest.FinancialEntities.Tests.Services
{
    [TestFixture]
    public class GivenAnEntityExtractionService
    {
        private IEntityExtractionService _sut;
        private Mock<IMarketItemsRepository> _mockRepository;
        private Mock<IExtractionStrategy> _mockStrategy;
        private Mock<IExtractionStrategy> _mockSecondStrategy;
        private Mock<ILogger<EntityExtractionService>> _logger;
        private List<IExtractionStrategy> _extractionStrategies;

        [SetUp]
        public void SetUp()
        {
            _mockStrategy = new Mock<IExtractionStrategy>();
            _mockSecondStrategy = new Mock<IExtractionStrategy>();
            _extractionStrategies = new List<IExtractionStrategy>();
            _mockRepository = new Mock<IMarketItemsRepository>();
            _logger = new Mock<ILogger<EntityExtractionService>>();

            _extractionStrategies.Add(_mockStrategy.Object);
            _extractionStrategies.Add(_mockSecondStrategy.Object);

            _sut = new EntityExtractionService(_mockRepository.Object
                , _extractionStrategies
                , _logger.Object);
        }

        [Test]
        public void WhenExtractEntitiesIsCalled_AndNoEnabledStrategiesExist_ThenAnEmptyListIsReturned()
        {
            _mockRepository.Setup(x => x.GetMarketItems()).Throws<ArgumentException>();

            var results = _sut.ExtractEntities();

            results.Should().BeEmpty().And.BeOfType<List<string>>();
        }
        [Test]
        public void WhenExtractEntitiesIsCalledWithAnEnabledStrategy_AndAnExecptionIsThrown_ThenAnEmptyListIsReturned()
        {

            _mockStrategy.Setup(x => x.IsEnabled).Returns(true);
            _mockStrategy.Setup(x => x.ExtractEntity(It.IsAny<List<MarketItem>>())).Throws<ArgumentException>();
            _mockRepository.Setup(x => x.GetMarketItems()).Throws<ArgumentException>();

            var results = _sut.ExtractEntities();
            using (new AssertionScope())
            {
                results.Should().BeEmpty().And.BeOfType<List<string>>();
                _logger.VerifyLogging("Extraction failed", LogLevel.Error);
            }
        }
        [Test]
        public void WhenExtractEntitiesIsCalledWithAnEnabledStrategy_AndAMatchIsFound_ThenAListIsReturned()
        {
            var expectedResult = new List<string> { "one", "two" };
            _mockStrategy.Setup(x => x.IsEnabled).Returns(true);
            _mockStrategy.Setup(x => x.ExtractEntity(It.IsAny<List<MarketItem>>())).Returns(expectedResult);

            var results = _sut.ExtractEntities();
            results.Should().HaveCount(2)
                .And.BeOfType<List<string>>()
                .And.BeEquivalentTo(expectedResult);
        }

        [Test]
        public void WhenExtractEntitiesIsCalledWithMultipleEnabledStrategy_AndMatchesAreFound_ThenADistinctListIsReturned()
        {
            var expectedResult = new List<string> { "one", "two", "three" };
            _mockStrategy.Setup(x => x.IsEnabled).Returns(true);
            _mockStrategy.Setup(x => x.ExtractEntity(It.IsAny<List<MarketItem>>())).Returns(new List<string> { "one", "two" });
            _mockSecondStrategy.Setup(x => x.IsEnabled).Returns(true);
            _mockSecondStrategy.Setup(x => x.ExtractEntity(It.IsAny<List<MarketItem>>())).Returns(new List<string> { "two", "three" });

            var results = _sut.ExtractEntities();
            results.Should().HaveCount(3)
                .And.BeOfType<List<string>>()
                .And.BeEquivalentTo(expectedResult);
        }
    }
}
