using AuctionSite.Shared;
using AuctionSite.Shared.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSite.Api
{
    public static class StartupExtensions
    {
        public static AuthenticationBuilder AddAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddAuthentication()
                .AddFacebookAuth(configuration);
        }

        public static AuthenticationBuilder AddFacebookAuth(this AuthenticationBuilder authBuilder, IConfiguration configuration)
        {
            var facebookConfiguration = configuration.GetSection(Constants.Configuration.FacebookAuthRoot)
                .Get<FacebookAuthConfiguration>();

            return authBuilder.AddFacebook(options =>
            {
                options.AppId = facebookConfiguration.AppId;
                options.AppSecret = facebookConfiguration.AppSecret;
            });
        }
    }
}
