using AuctionSite.DataAccess.DbConnection;
using AuctionSite.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace AuctionSite.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuctionSiteDbContext _context;
        public IAuctionRepository Auction { get; }
        public IBidRepository Bid { get; }
        public ICategoryRepository Category { get; }
        public IOpinionRepository Opinion { get; }
        public IPictureRepository Picture { get; }
        public IUserOpinionThumbRepository UserOpinionThumb { get; }
        public IUserRepository User { get; }

        public UnitOfWork(AuctionSiteDbContext context, IAuctionRepository auction, IBidRepository bid, 
            ICategoryRepository category, IOpinionRepository opinion, IPictureRepository picture, 
            IUserOpinionThumbRepository userOpinionThumb, IUserRepository user)
        {
            _context = context;
            Auction = auction;
            Bid = bid;
            Category = category;
            Opinion = opinion;
            Picture = picture;
            UserOpinionThumb = userOpinionThumb;
            User = user;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
