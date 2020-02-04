using System;
using Microsoft.EntityFrameworkCore;
using UsuallyBoughtTogetherApi.Dtos;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi
{
    public class PredictionContext : DbContext
    {
        public PredictionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntryEntity> ProductEntryEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntryEntity>().HasKey(p => p.ProductEntryId);
            modelBuilder.Entity<ProductEntryEntity>().Property(p => p.Created).ValueGeneratedOnAdd();
        }
    }
}