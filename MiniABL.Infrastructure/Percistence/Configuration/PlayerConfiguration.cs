using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasIndex(p => p.PlayerId);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.DateOfBirth).IsRequired();
            builder.HasMany(p => p.Licenses)
                .WithOne(l => l.Player)
                .HasForeignKey(l => l.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
