using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSite.DataAccess.Model.EntityConfig
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(user => user.LastName)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(user => user.MiddleNames)
                .IsRequired(false)
                .HasMaxLength(128);

            builder
                .Property(user => user.BirthDate)
                .IsRequired(false);

            builder
                .Property(user => user.FailedLoginAttempts)
                .IsRequired();

            builder
                .Property(user => user.RecoveryGuid)
                .IsRequired(false);

            builder
                .Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(user => user.CreationDate)
                .IsRequired();

            builder
                .Property(user => user.DeletionDate)
                .IsRequired(false);

            builder
                .Property(user => user.LastModificationDate)
                .IsRequired(false);

            builder
                .Property(user => user.PasswordHash)
                .IsRequired(false)
                .HasMaxLength(64);

            builder
                .Property(user => user.Role)
                .IsRequired();

            builder
                .Property(user => user.IsSuperSeller)
                .IsRequired();

            builder
                .Property(user => user.RecoveryValidDate)
                .IsRequired(false);

            builder
                .Property(user => user.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(12);
        }
    }
}
