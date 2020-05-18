using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class UserOpinionThumbEntityConfig : IEntityTypeConfiguration<UserOpinionThumb>
    {
        public void Configure(EntityTypeBuilder<UserOpinionThumb> builder)
        {
            builder
                .HasKey(userOpinionThumb => new {userOpinionThumb.UserId, userOpinionThumb.OpinionId});

            builder
                .Property(userOpinionThumb => userOpinionThumb.IsPositive)
                .IsRequired();

            builder
                .HasOne(userOpinionThumb => userOpinionThumb.User)
                .WithMany(user => user.UserOpinionThumbs)
                .HasForeignKey(userOpinionThumb => userOpinionThumb.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(userOpinionThumb => userOpinionThumb.Opinion)
                .WithMany(opinion => opinion.UserOpinionThumbs)
                .HasForeignKey(userOpinionThumb => userOpinionThumb.OpinionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
