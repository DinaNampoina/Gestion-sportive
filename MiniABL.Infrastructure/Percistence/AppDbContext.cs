using Microsoft.EntityFrameworkCore;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) :DbContext(option)
    {
        public DbSet<Player> PlayerId { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
