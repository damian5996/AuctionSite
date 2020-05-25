using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.Api
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureCustomAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }
    }
}
