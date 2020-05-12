using AuctionSite.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.BL
{
    public static class BusinessLogicStartupExtensions
    {
        public static IServiceCollection BusinessLogicConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .DataAccessConfiguration(configuration);
        }
    }
}
