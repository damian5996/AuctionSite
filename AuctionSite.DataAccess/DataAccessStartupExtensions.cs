using AuctionSite.DataAccess.DbConnection;
using AuctionSite.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.DataAccess
{
    public static class DataAccessStartupExtensions
    {
        public static IServiceCollection DataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .DatabaseConnectionConfiguration(configuration);
        }

        public static IServiceCollection DatabaseConnectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<AuctionSiteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.Database.DefaultConnectionString)));
        }
    }
}
