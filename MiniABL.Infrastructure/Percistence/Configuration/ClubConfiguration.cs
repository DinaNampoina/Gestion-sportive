using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence.Configuration
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasIndex(c => c.ClubId);
            builder.Property(c => c.ClubName).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Licenses)
                .WithOne(l => l.Club)
                .HasForeignKey(l => l.ClubId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
