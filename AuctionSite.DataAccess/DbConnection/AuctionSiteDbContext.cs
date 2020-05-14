using AuctionSite.DataAccess.Model;
using AuctionSite.DataAccess.Model.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace AuctionSite.DataAccess.DbConnection
{
    public class AuctionSiteDbContext : DbContext
    {
        public AuctionSiteDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Auction> Auction { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Opinion> Opinion { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<ReportedAuction> ReportedAuction { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOpinionThumb> UserOpinionThumb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuctionEntityConfig());
            modelBuilder.ApplyConfiguration(new BidEntityConfig());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfig());
            modelBuilder.ApplyConfiguration(new OpinionEntityConfig());
            modelBuilder.ApplyConfiguration(new PictureEntityConfig());
            modelBuilder.ApplyConfiguration(new ReportedAuctionEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new UserOpinionThumbEntityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
