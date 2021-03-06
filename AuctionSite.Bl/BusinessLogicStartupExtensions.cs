﻿using AuctionSite.BL.Common.Services;
using AuctionSite.BL.User;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.BL
{
    public static class BusinessLogicStartupExtensions
    {
        public static IServiceCollection BusinessLogicConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .DataAccessConfigureServices(configuration)
                .AddBusinessLogicDependencies();
        }

        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserFacebookAuthenticationLogic, UserFacebookAuthenticationLogic>()
                .AddScoped<IRegisterUserLogic, RegisterUserLogic>()
                .AddScoped<EmailService>();
        }

        public static IApplicationBuilder BusinessLogicConfigure(this IApplicationBuilder app)
        {
            return app
                .DataAccessConfigure();
        }
    }
}
