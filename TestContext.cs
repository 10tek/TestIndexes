﻿using IndexTests.Models;
using Microsoft.EntityFrameworkCore;

namespace IndexTests
{
    public class TestContext : DbContext
    {
        private readonly string connectionString;

        public TestContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasIndex(x => x.FileName);
            modelBuilder.Entity<Photo>().HasIndex(x => new { x.Latitude, x.Longitude });
        }
    }
}
