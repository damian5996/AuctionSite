using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class OpinionEntityConfig : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasKey(opinion => opinion.Id);

            builder
                .Property(opinion => opinion.Content)
                .IsRequired()
                .HasMaxLength(512);

            builder
                .Property(opinion => opinion.Rate)
                .IsRequired();

            builder.HasOne(opinion => opinion.Author)
                .WithMany(user => user.Opinions)
                .HasForeignKey(opinion => opinion.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(opinion => opinion.Auction)
                .WithMany(auction => auction.Opinions)
                .HasForeignKey(opinion => opinion.AuctionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
