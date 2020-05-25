using System.Threading.Tasks;
using AuctionSite.Shared.Dto;

namespace AuctionSite.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetByEmailOrDefaultAsync(string email);
    }
}
