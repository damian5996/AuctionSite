using System.Linq;
using System.Threading.Tasks;
using AuctionSite.DataAccess.Model;
using AuctionSite.Shared.Dto;

namespace AuctionSite.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetByEmailOrDefaultAsync(string email);
        IQueryable<UserDto> GetAll();
        Task<bool> AddUser(UserDto userDto);
    }
}
