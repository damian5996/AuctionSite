using System.Linq;
using System.Threading.Tasks;
using AuctionSite.DataAccess.DbConnection;
using AuctionSite.DataAccess.Model;
using AuctionSite.DataAccess.Repositories.Interfaces;
using AuctionSite.Shared.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionSite.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuctionSiteDbContext _db;
        private readonly IMapper _mapper;

        public UserRepository(AuctionSiteDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByEmailOrDefaultAsync(string email)
        {
            return _mapper.Map<UserDto>(await _db.User.FirstOrDefaultAsync(user => user.Email == email));
        }

        public bool WithThisEmailExists(string email)
        {
            return _db.User.Any(user => user.Email == email);
        }

        public bool WithThisUsernameExists(string username)
        {
            return _db.User.Any(user => user.Username == username);
        }

        public async Task<int> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _db.User.AddAsync(user);

            return await _db.SaveChangesAsync();
        }

        private async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
