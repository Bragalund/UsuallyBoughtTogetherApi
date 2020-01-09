using Microsoft.EntityFrameworkCore;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi
{
    public class PredictionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        
        public DbSet<ProductEntryEntity> ProductEntryEntities { get; set; }
    }
}