using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class PictureEntityConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasKey(picture => picture.Id);

            builder
                .Property(picture => picture.BlobName)
                .IsRequired()
                .HasMaxLength(36);

            builder
                .HasOne(picture => picture.Auction)
                .WithMany(auction => auction.Pictures)
                .HasForeignKey(picture => picture.AuctionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
