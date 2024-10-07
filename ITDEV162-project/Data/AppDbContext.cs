using Microsoft.EntityFrameworkCore;
using ClothingBrandApi.Models;

namespace ClothingBrandApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClothingItem> ClothingItems { get; set; }
    }
}