using AuctionSite.DataAccess.DbConnection;
using AuctionSite.DataAccess.Repositories;
using AuctionSite.DataAccess.Repositories.Interfaces;
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
                .DatabaseConnectionConfiguration(configuration)
                .AddDependencies();
        }

        private static IServiceCollection DatabaseConnectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<AuctionSiteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.Database.DefaultConnectionString)));
        }
        private static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IAuctionRepository, AuctionRepository>()
                .AddScoped<IBidRepository, BidRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IOpinionRepository, OpinionRepository>()
                .AddScoped<IPictureRepository, PictureRepository>()
                .AddScoped<IUserOpinionThumbRepository, UserOpinionThumbRepository>()
                .AddScoped<IUserRepository, UserRepository>();
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
