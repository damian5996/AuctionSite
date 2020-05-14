using Microsoft.EntityFrameworkCore;

namespace AuctionSite.DataAccess.DbConnection
{
    public class AuctionSiteDbContext : DbContext
    {
        public AuctionSiteDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
