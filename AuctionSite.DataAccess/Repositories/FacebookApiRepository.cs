using AuctionSite.DataAccess.Repositories.Interfaces;
using AuctionSite.Shared.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AuctionSite.Shared.Dto;

namespace AuctionSite.DataAccess.Repositories
{
    public class FacebookApiRepository : IFacebookApiRepository
    {
        private readonly FacebookApiConfiguration _facebookApiConfiguration;

        public FacebookApiRepository(FacebookApiConfiguration facebookApiConfiguration)
        {
            _facebookApiConfiguration = facebookApiConfiguration;
        }

        public async Task<bool> ValidateToken(string token)
        {
            var url = _facebookApiConfiguration.BaseUrl + string.Format(
                          _facebookApiConfiguration.ValidateTokenMethodPathTemplate, token,
                          _facebookApiConfiguration.AccessToken);

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_facebookApiConfiguration.BaseUrl);

            var result = await httpClient.GetAsync(url);

            result.EnsureSuccessStatusCode();

            var facebookUserId = await JsonSerializer.DeserializeAsync<FacebookRequestResultDto<FacebookUserIdDto>>(await result.Content.ReadAsStreamAsync());

            return facebookUserId.Content.IsValidated;
        }
    }
}
