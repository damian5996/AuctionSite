using System.Reflection;
using AuctionSite.Shared.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AuctionSite.Shared
{
    public static class SharedStartupExtensions
    {
        public static IServiceCollection SharedConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSharedDependencies(configuration);
        }

        public static IServiceCollection AddSharedDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddSingleton(configuration.GetSection(Constants.Configuration.FacebookApiConfigurationRoot)
                    .Get<FacebookApiConfiguration>());
        }
    }
}
