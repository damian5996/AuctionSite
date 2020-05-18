using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class BidEntityConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder
                .HasKey(bid => bid.Id);

            builder
                .Property(bid => bid.Price)
                .HasColumnType("decimal(11,2)")
                .IsRequired();

            builder
                .Property(bid => bid.Timestamp)
                .IsRequired();

            builder
                .HasOne(bid => bid.User)
                .WithMany(user => user.Bids)
                .HasForeignKey(bid => bid.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(bid => bid.Auction)
                .WithMany(auction => auction.Bids)
                .HasForeignKey(bid => bid.AuctionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
