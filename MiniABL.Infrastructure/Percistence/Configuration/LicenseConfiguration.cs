using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence.Configuration
{
    public class LicenseConfiguration : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.HasIndex(l => l.LicenseId);
            builder.Property(l => l.Numero).IsRequired().HasMaxLength(10);
            builder.Property(l => l.Statut).IsRequired();
            builder.Property(l => l.DateCreat).IsRequired();
            //category
            builder.HasOne(l => l.Category)
            .WithMany(c => c.Licenses)
            .HasForeignKey(l => l.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            //player
            builder.HasOne(l => l.Player)
                .WithMany(p => p.Licenses)
                .HasForeignKey(l => l.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
            //club
            builder.HasOne(l => l.Club)
            .WithMany(c => c.Licenses)
            .HasForeignKey(l => l.ClubId)
            .OnDelete(DeleteBehavior.Restrict);
            //season
            builder.HasOne(l => l.Season)
            .WithMany(c => c.Licenses)
            .HasForeignKey(l => l.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
