using FluentAssertions;
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

namespace VoxSmart.TechTest.FinancialEntities.Tests.Mappers
{
    [TestFixture]
    public class GivenAnMarketItemMapper
    {
        private IMarketItemMapper _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new MarketItemMapper();
        }

        [Test]
        public void WhenToItemIsCalledWithASyndicationItem_ThenAMarketItemIsReturned()
        {
            var expectedDate = DateTime.Parse("01/01/2001 00:00:00");
            var syndicationItem = new SyndicationItem
            {
                Title = new TextSyndicationContent("Title"),
                Summary = new TextSyndicationContent("Description"),
                PublishDate = expectedDate
            };

            var expectedResult = new MarketItem
            {
                Description = "Description",
                Title = "Title",
                PubDate = expectedDate
            };

            var result = _sut.ToItem(syndicationItem);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void WhenToItemIsCalledWithANullSyndicationItem_ThenANullReferenceExceptionIsThrown()
        {
            var expectedDate = DateTime.Parse("01/01/2001 00:00:00");

            Action act = () => _sut.ToItem(null);

            act.Should().Throw<NullReferenceException>();
        }
    }
}
