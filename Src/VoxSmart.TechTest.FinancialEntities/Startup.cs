
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoxSmart.TechTest.FinancialEntities.Interfaces;
using VoxSmart.TechTest.FinancialEntities.Mappers;
using VoxSmart.TechTest.FinancialEntities.Models;
using VoxSmart.TechTest.FinancialEntities.Repositories;
using VoxSmart.TechTest.FinancialEntities.Services;
using VoxSmart.TechTest.FinancialEntities.Strategies;

namespace VoxSmart.TechTest.FinancialEntities
{
    public static class Startup
    {
        public static void AddExtractionService(this IServiceCollection services
            , IConfiguration config )
        {
            services.Configure<ExtractionConfiguration>(config.GetSection(nameof(ExtractionConfiguration)));
            services.AddScoped<IMarketItemsRepository, MarketItemsRepository>();
            services.AddScoped<IMarketItemMapper, MarketItemMapper>();
            services.AddScoped<IExtractionStrategy, AgriculturalCommoditiesStrategy>();
            services.AddScoped<IExtractionStrategy, MetalCommoditiesStrategy>();
            services.AddScoped<IExtractionStrategy, CurrencyCodesStrategy>();
            services.AddScoped<IEntityExtractionService, EntityExtractionService>();
        }
    }
}
