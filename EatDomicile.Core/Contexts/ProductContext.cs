using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EatDomicile.Core.Contexts
{
    public class ProductContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder
                .LogTo(
                    Console.WriteLine,
                    (eventId, level) => eventId == RelationalEventId.CommandExecuting,
                    DbContextLoggerOptions.None
                )
                .UseSqlServer("Server=localhost;Database=EatDomicile;Trusted_Connection=True;TrustServerCertificate=True;");

#else
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=EatDomicile;Trusted_Connection=True;TrustServerCertificate=True;");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
            modelBuilder.Entity<Product>()
                .UseTptMappingStrategy();

            modelBuilder.Entity<Food>()
                .UseTptMappingStrategy();

            
        }

        public DbSet<Pizza> Pizzas => this.Set<Pizza>();
        public DbSet<Pasta> Pastas => this.Set<Pasta>();
        public DbSet<Burger> Burgers => this.Set<Burger>();
        public DbSet<Drink> Drinks => this.Set<Drink>();
        public DbSet<Dough> Doughs => this.Set<Dough>();

        public DbSet<User> Users => this.Set<User>();
        public DbSet<Address> Addresses => this.Set<Address>();
       
        public DbSet<Ingredient> Ingredients => this.Set<Ingredient>();
        public DbSet<Order> Orders => this.Set<Order>();
        public DbSet<Food> Foods => this.Set<Food>();

    }
}
