using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class AuctionEntityConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder
                .HasKey(auction => auction.Id);

            builder
                .Property(auction => auction.Title)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(auction => auction.Description)
                .IsRequired(false)
                .HasMaxLength(4096);

            builder
                .Property(auction => auction.IsBidType)
                .IsRequired(false);

            builder
                .Property(auction => auction.Price)
                .HasColumnType("decimal(11,2)")
                .IsRequired(false);

            builder
                .Property(auction => auction.Status)
                .IsRequired();

            builder
                .Property(auction => auction.CreationDate)
                .IsRequired();

            builder
                .Property(auction => auction.StartDate)
                .IsRequired(false);

            builder
                .Property(auction => auction.EndDate)
                .IsRequired(false);

            builder
                .Property(auction => auction.LastModificationDate)
                .IsRequired(false);

            builder
                .HasOne(auction => auction.BoughtBy)
                .WithMany(user => user.BoughtAuctions)
                .HasForeignKey(auction => auction.BoughtById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(auction => auction.Owner)
                .WithMany(user => user.CreatedAuctions)
                .HasForeignKey(auction => auction.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(auction => auction.Category)
                .WithMany(category => category.Auctions)
                .HasForeignKey(auction => auction.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
