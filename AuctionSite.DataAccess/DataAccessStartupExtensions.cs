using AuctionSite.DataAccess.DbConnection;
using AuctionSite.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.DataAccess
{
    public static class DataAccessStartupExtensions
    {
        public static IServiceCollection DataAccessConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .DatabaseConnectionConfiguration(configuration);
        }

        public static IServiceCollection DatabaseConnectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<AuctionSiteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.Database.DefaultConnectionString)));
        }

        public static IApplicationBuilder DataAccessConfigure(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetRequiredService<AuctionSiteDbContext>();

            context.Database.Migrate();
            return app;
        }
    }
}
