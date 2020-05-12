using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.DataAccess
{
    public static class DataAccessStartupExtensions
    {
        public static IServiceCollection DataAccessConfiguration(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection DatabaseConnectionConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}
