using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class ReportedAuctionEntityConfig : IEntityTypeConfiguration<ReportedAuction>
    {
        public void Configure(EntityTypeBuilder<ReportedAuction> builder)
        {
            builder.HasKey(reportedAuction => reportedAuction.Id);

            builder
                .Property(reportedAuction => reportedAuction.Type)
                .IsRequired();

            builder
                .Property(reportedAuction => reportedAuction.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(reportedAuction => reportedAuction.Status)
                .IsRequired();

            builder.HasOne(reportedAuction => reportedAuction.Reporter)
                .WithMany(user => user.ReportedAuctions)
                .HasForeignKey(reportedAuction => reportedAuction.ReporterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(reportedAuction => reportedAuction.Auction)
                .WithMany(auction => auction.Reports)
                .HasForeignKey(reportedAuction => reportedAuction.AuctionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
