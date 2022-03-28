using System;
using Microsoft.EntityFrameworkCore;
using StoreModel.Models;

namespace StoreModel.Contexts
{
    public class StoreItemContext : DbContext
    {
        public DbSet<Beverage> BeverageItems { get; set; }
        public DbSet<Candy> CandyItems { get; set; }
        public DbSet<Meat> MeatItems { get; set; }
        public DbSet<Vegetable> VegetableItems { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=localhost;Database=StoreModel;User=sa;Password=Wardruna-532");
    }
}
