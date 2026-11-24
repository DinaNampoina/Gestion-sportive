using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(20);
            builder.Property(c => c.MinAge).IsRequired();
            builder.Property(c => c.MaxAge).IsRequired();
            builder.HasMany(c => c.Licenses)
                .WithOne(l => l.Category)
                .HasForeignKey(l => l.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
