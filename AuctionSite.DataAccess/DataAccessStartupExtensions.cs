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
                .AddDataAccessDependencies();
        }

        public static IServiceCollection DatabaseConnectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<AuctionSiteDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.Database.DefaultConnectionString)));
        }

        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IFacebookApiRepository, FacebookApiRepository>()
                .AddScoped<IAuctionRepository, AuctionRepository>()
                .AddScoped<IBidRepository, BidRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IOpinionRepository, OpinionRepository>()
                .AddScoped<IPictureRepository, PictureRepository>()
                .AddScoped<IUserOpinionThumbRepository, UserOpinionThumbRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
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
