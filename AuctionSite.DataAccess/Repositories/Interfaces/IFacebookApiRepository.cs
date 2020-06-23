using AuctionSite.Shared.Dto.Facebook;
using System.Threading.Tasks;

namespace AuctionSite.DataAccess.Repositories.Interfaces
{
    public interface IFacebookApiRepository
    {
        Task<bool> ValidateTokenAsync(string token);
        Task<FacebookUserDto> GetUserInfoAsync(string token);
    }
}
