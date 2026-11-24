using Microsoft.EntityFrameworkCore;
using MiniABL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure.Percistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) :DbContext(option)
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<License> Licenses => Set<License>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
