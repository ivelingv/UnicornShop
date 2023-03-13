using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Models;

namespace UnicornShop.Infrastructure.Database.Configuration
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=main.db", config =>
                {
                    config.MigrationsAssembly("UnicornShop.Infrastructure");
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                optionsBuilder.EnableDetailedErrors(true);
                optionsBuilder.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
