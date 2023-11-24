using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxSmart.TechTest.FinancialEntities.Interfaces;

namespace VoxSmart.TechTest.FinancialEntities.Tests.Integrations
{
    [TestFixture]
    public class IntegrationTest_GivenAnEntityExtractionService
    {
        private IEntityExtractionService _sut;

        [SetUp]
        public void Setup()
        {
            var host = ConfigureHost();
            _sut = host.Services.GetRequiredService<IEntityExtractionService>();

        }

        [Test]
        public void WhenExtractEntitiesIsCalled_ThenAListOfEntitiesIsReturned()
        {
            var result = _sut.ExtractEntities();

            result.Should().BeOfType<List<string>>().And.NotBeNull();

        }


        private IHost ConfigureHost()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddExtractionService(builder.Configuration);
            return builder.Build();
        }
    }
}
