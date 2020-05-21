using System.Threading.Tasks;

namespace AuctionSite.DataAccess.Repositories.Interfaces
{
    public interface IFacebookApiRepository
    {
        Task<bool> ValidateToken(string token);
    }
}
