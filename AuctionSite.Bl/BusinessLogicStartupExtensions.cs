using AuctionSite.BL.User;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace AuctionSite.BL
{
    public static class BusinessLogicStartupExtensions
    {
        public static IServiceCollection BusinessLogicConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .DataAccessConfigureServices(configuration)
                .AddScoped<IRegisterUserLogic, RegisterUserLogic>();
        }

        public static IApplicationBuilder BusinessLogicConfigure(this IApplicationBuilder app)
        {
            return app
                .DataAccessConfigure();
        }
    }
}
