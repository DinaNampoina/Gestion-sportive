using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence.Configuration
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasIndex(s => s.SeasonId);
            builder.Property(s => s.StartDate).IsRequired();
            builder.Property(s => s.Statut).IsRequired();
            builder.Property(s => s.EndDate).IsRequired();
            builder.HasMany(s => s.Licenses)
                .WithOne(l => l.Season)
                .HasForeignKey(l => l.SeasonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
