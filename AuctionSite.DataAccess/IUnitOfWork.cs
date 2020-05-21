using AuctionSite.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace AuctionSite.DataAccess
{
    public interface IUnitOfWork
    {
        IAuctionRepository Auction { get; }
        IBidRepository Bid { get; }
        ICategoryRepository Category { get; }
        IOpinionRepository Opinion { get; }
        IPictureRepository Picture { get; }
        IUserOpinionThumbRepository UserOpinionThumb { get; }
        IUserRepository User { get; }

        Task<int> SaveAsync();
    }
}
