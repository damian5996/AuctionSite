using System.Threading.Tasks;
using AuctionSite.Shared.Dto;

namespace AuctionSite.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetByEmailOrDefaultAsync(string email);
        bool WithThisEmailExists(string email);
        bool WithThisUsernameExists(string username);
        Task<int> AddUser(UserDto userDto);
    }
}
