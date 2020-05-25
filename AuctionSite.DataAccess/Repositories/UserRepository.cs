using System.Threading.Tasks;
using AuctionSite.DataAccess.DbConnection;
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
    }
}
