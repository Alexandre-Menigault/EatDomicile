using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Contexts
{
    public static class ProductContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedAddresses(modelBuilder);
            SeedUsers(modelBuilder);
            SeedDoughs(modelBuilder);
            SeedPastas(modelBuilder);
            SeedPizzas(modelBuilder);
            SeedBurgers(modelBuilder);
            SeedIngredients(modelBuilder);
            SeedDrinks(modelBuilder);
            SeedOrders(modelBuilder);
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Rue de la Paix", City = "Paris", State = "Île-de-France", ZipCode = 75001, Country = "France" },
                new Address { Id = 2, Street = "456 Avenue des Champs", City = "Lyon", State = "Auvergne-Rhône-Alpes", ZipCode = 69001, Country = "France" },
                new Address { Id = 3, Street = "789 Boulevard Victor Hugo", City = "Marseille", State = "Provence-Alpes-Côte d'Azur", ZipCode = 13001, Country = "France" },
                new Address { Id = 4, Street = "12 Rue du Commerce", City = "Toulouse", State = "Occitanie", ZipCode = 31000, Country = "France" },
                new Address { Id = 5, Street = "34 Place de la République", City = "Nice", State = "Provence-Alpes-Côte d'Azur", ZipCode = 6000, Country = "France" },
                new Address { Id = 6, Street = "56 Rue Saint-Michel", City = "Nantes", State = "Pays de la Loire", ZipCode = 44000, Country = "France" },
                new Address { Id = 7, Street = "78 Avenue Jean Jaurès", City = "Strasbourg", State = "Grand Est", ZipCode = 67000, Country = "France" },
                new Address { Id = 8, Street = "90 Rue de la Liberté", City = "Lille", State = "Hauts-de-France", ZipCode = 59000, Country = "France" },
                new Address { Id = 9, Street = "11 Boulevard des Allées", City = "Bordeaux", State = "Nouvelle-Aquitaine", ZipCode = 33000, Country = "France" },
                new Address { Id = 10, Street = "22 Rue du Marché", City = "Rennes", State = "Bretagne", ZipCode = 35000, Country = "France" },
                new Address { Id = 11, Street = "33 Avenue de la Gare", City = "Montpellier", State = "Occitanie", ZipCode = 34000, Country = "France" },
                new Address { Id = 12, Street = "44 Rue des Écoles", City = "Grenoble", State = "Auvergne-Rhône-Alpes", ZipCode = 38000, Country = "France" }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new { Id = 1, FirstName = "Jean", LastName = "Dupont", Email = "jean.dupont@email.fr", Phone = "0612345678", AddressId = 1 },
                new { Id = 2, FirstName = "Marie", LastName = "Martin", Email = "marie.martin@email.fr", Phone = "0623456789", AddressId = 2 },
                new { Id = 3, FirstName = "Pierre", LastName = "Bernard", Email = "pierre.bernard@email.fr", Phone = "0634567890", AddressId = 3 },
                new { Id = 4, FirstName = "Sophie", LastName = "Dubois", Email = "sophie.dubois@email.fr", Phone = "0645678901", AddressId = 4 },
                new { Id = 5, FirstName = "Luc", LastName = "Thomas", Email = "luc.thomas@email.fr", Phone = "0656789012", AddressId = 5 },
                new { Id = 6, FirstName = "Emma", LastName = "Robert", Email = "emma.robert@email.fr", Phone = "0667890123", AddressId = 6 },
                new { Id = 7, FirstName = "Antoine", LastName = "Petit", Email = "antoine.petit@email.fr", Phone = "0678901234", AddressId = 7 },
                new { Id = 8, FirstName = "Julie", LastName = "Richard", Email = "julie.richard@email.fr", Phone = "0689012345", AddressId = 8 },
                new { Id = 9, FirstName = "Nicolas", LastName = "Durand", Email = "nicolas.durand@email.fr", Phone = "0690123456", AddressId = 9 },
                new { Id = 10, FirstName = "Claire", LastName = "Simon", Email = "claire.simon@email.fr", Phone = "0601234567", AddressId = 10 }
            );
        }

        private static void SeedDoughs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dough>().HasData(
                new Dough { Id = 1, Name = "Pâte Fine" },
                new Dough { Id = 2, Name = "Pâte Épaisse" },
                new Dough { Id = 3, Name = "Pâte Croustillante" },
                new Dough { Id = 4, Name = "Pâte Pan" },
                new Dough { Id = 5, Name = "Pâte aux Céréales" },
                new Dough { Id = 6, Name = "Pâte au Fromage" },
                new Dough { Id = 7, Name = "Pâte Sans Gluten" },
                new Dough { Id = 8, Name = "Pâte à l'Ail" },
                new Dough { Id = 9, Name = "Pâte Napolitaine" },
                new Dough { Id = 10, Name = "Pâte New Yorkaise" }
            );
        }

        private static void SeedIngredients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Mozzarella", Kcal = 280, Allergene = true, BurgerId = 21 },
                new Ingredient { Id = 2, Name = "Tomate", Kcal = 18, Allergene = false, BurgerId = 22 },
                new Ingredient { Id = 3, Name = "Basilic", Kcal = 23, Allergene = false, BurgerId = 22 },
                new Ingredient { Id = 4, Name = "Jambon", Kcal = 145, Allergene = false, BurgerId = 22 },
                new Ingredient { Id = 5, Name = "Champignons", Kcal = 22, Allergene = false, BurgerId = 23 },
                new Ingredient { Id = 6, Name = "Olives", Kcal = 115, Allergene = false, BurgerId = 23 },
                new Ingredient { Id = 7, Name = "Poivrons", Kcal = 31, Allergene = false, BurgerId = 24 },
                new Ingredient { Id = 8, Name = "Oignons", Kcal = 40, Allergene = false, BurgerId = 25  },
                new Ingredient { Id = 9, Name = "Pepperoni", Kcal = 494, Allergene = false, BurgerId = 26 },
                new Ingredient { Id = 10, Name = "Anchois", Kcal = 131, Allergene = true, BurgerId = 27 },
                new Ingredient { Id = 11, Name = "Salade", Kcal = 15, Allergene = false, BurgerId = 28 },
                new Ingredient { Id = 12, Name = "Steak Haché", Kcal = 250, Allergene = false, BurgerId = 28 },
                new Ingredient { Id = 13, Name = "Bacon", Kcal = 541, Allergene = false, BurgerId = 29 },
                new Ingredient { Id = 14, Name = "Cheddar", Kcal = 403, Allergene = true, BurgerId = 29 },
                new Ingredient { Id = 15, Name = "Cornichons", Kcal = 11, Allergene = false, BurgerId = 21 },
                new Ingredient { Id = 16, Name = "Sauce BBQ", Kcal = 172, Allergene = false, BurgerId = 22 },
                new Ingredient { Id = 17, Name = "Sauce Ketchup", Kcal = 112, Allergene = false, BurgerId = 30 },
                new Ingredient { Id = 18, Name = "Sauce Mayonnaise", Kcal = 680, Allergene = true , BurgerId = 30},
                new Ingredient { Id = 19, Name = "Poulet", Kcal = 165, Allergene = false, BurgerId = 30 },
                new Ingredient { Id = 20, Name = "Roquette", Kcal = 25, Allergene = false, BurgerId = 25 }
            );
        }

        private static void SeedPizzas(ModelBuilder modelBuilder)
        {
            // Seed Pizza products first
            modelBuilder.Entity<Pizza>().HasData(
                new { Id = 1, Name = "Margherita", Price = 9.90m, Vegetarien = true, DoughId = 1 },
                new { Id = 2, Name = "Regina", Price = 11.50m, Vegetarien = false, DoughId = 2 },
                new { Id = 3, Name = "Quatre Fromages", Price = 12.90m, Vegetarien = true, DoughId = 1 },
                new { Id = 4, Name = "Pepperoni", Price = 11.90m, Vegetarien = false, DoughId = 3 },
                new { Id = 5, Name = "Végétarienne", Price = 10.90m, Vegetarien = true, DoughId = 1 },
                new { Id = 6, Name = "Calzone", Price = 13.50m, Vegetarien = false, DoughId = 4 },
                new { Id = 7, Name = "Napolitaine", Price = 10.50m, Vegetarien = false, DoughId = 9 },
                new { Id = 8, Name = "Sicilienne", Price = 12.50m, Vegetarien = false, DoughId = 1 },
                new { Id = 9, Name = "Paysanne", Price = 11.90m, Vegetarien = false, DoughId = 2 },
                new { Id = 10, Name = "Orientale", Price = 12.90m, Vegetarien = false, DoughId = 3 }
            );
        }

        private static void SeedPastas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasta>().HasData(
                new { Id = 11, Name = "Spaghetti Carbonara", Price = 10.90m, Vegetarien = false, Type = PastaType.Spaghetti, KCal = 450 },
                new { Id = 12, Name = "Penne Arrabiata", Price = 9.90m, Vegetarien = true, Type = PastaType.Penne, KCal = 380 },
                new { Id = 13, Name = "Fusilli au Pesto", Price = 11.50m, Vegetarien = true, Type = PastaType.Fusilli, KCal = 420 },
                new { Id = 14, Name = "Fettuccine Alfredo", Price = 12.90m, Vegetarien = true, Type = PastaType.Fettuccine, KCal = 520 },
                new { Id = 15, Name = "Linguine aux Fruits de Mer", Price = 14.90m, Vegetarien = false, Type = PastaType.Linguine, KCal = 480 },
                new { Id = 16, Name = "Rigatoni Bolognaise", Price = 11.90m, Vegetarien = false, Type = PastaType.Rigatoni, KCal = 510 },
                new { Id = 17, Name = "Farfalle au Saumon", Price = 13.50m, Vegetarien = false, Type = PastaType.Farfalle, KCal = 490 },
                new { Id = 18, Name = "Lasagnes Maison", Price = 12.50m, Vegetarien = false, Type = PastaType.Lasagna, KCal = 550 },
                new { Id = 19, Name = "Macaroni au Fromage", Price = 9.50m, Vegetarien = true, Type = PastaType.Macaroni, KCal = 470 },
                new { Id = 20, Name = "Penne 4 Fromages", Price = 12.90m, Vegetarien = true, Type = PastaType.Penne, KCal = 530 }
            );
        }

        private static void SeedBurgers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>().HasData(
                new { Id = 21, Name = "Burger Classic", Price = 8.90m, Vegetarien = false },
                new { Id = 22, Name = "Cheeseburger", Price = 9.50m, Vegetarien = false },
                new { Id = 23, Name = "Bacon Burger", Price = 10.90m, Vegetarien = false },
                new { Id = 24, Name = "Burger Végétarien", Price = 9.90m, Vegetarien = true },
                new { Id = 25, Name = "Double Cheese", Price = 12.50m, Vegetarien = false },
                new { Id = 26, Name = "BBQ Burger", Price = 11.50m, Vegetarien = false },
                new { Id = 27, Name = "Chicken Burger", Price = 9.90m, Vegetarien = false },
                new { Id = 28, Name = "Burger Savoyard", Price = 12.90m, Vegetarien = false },
                new { Id = 29, Name = "Burger Italien", Price = 11.90m, Vegetarien = false },
                new { Id = 30, Name = "Fish Burger", Price = 10.50m, Vegetarien = false }
            );
        }

        private static void SeedDrinks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasData(
                new { Id = 31, Name = "Coca-Cola", Price = 2.50m, Fizzy = true, KCal = 140 },
                new { Id = 32, Name = "Coca-Cola Zero", Price = 2.50m, Fizzy = true, KCal = 0 },
                new { Id = 33, Name = "Sprite", Price = 2.50m, Fizzy = true, KCal = 139 },
                new { Id = 34, Name = "Fanta Orange", Price = 2.50m, Fizzy = true, KCal = 150 },
                new { Id = 35, Name = "Ice Tea Pêche", Price = 2.90m, Fizzy = false, KCal = 120 },
                new { Id = 36, Name = "Eau Minérale", Price = 1.50m, Fizzy = false, KCal = 0 },
                new { Id = 37, Name = "Eau Pétillante", Price = 1.90m, Fizzy = true, KCal = 0 },
                new { Id = 38, Name = "Jus d'Orange", Price = 3.50m, Fizzy = false, KCal = 110 },
                new { Id = 39, Name = "Limonade", Price = 2.90m, Fizzy = true, KCal = 135 },
                new { Id = 40, Name = "Thé Glacé Citron", Price = 2.90m, Fizzy = false, KCal = 115 }
            );
        }

        private static void SeedOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2025, 9, 15, 12, 30, 0), DeliveryDate = new DateTime(2025, 9, 15, 13, 15, 0), Status = OrderStatus.Livree, UserId = 1, DeliveryAddressId = 1},
                new { Id = 2, OrderDate = new DateTime(2025, 9, 16, 19, 0, 0), DeliveryDate = new DateTime(2025, 9, 16, 19, 45, 0), Status = OrderStatus.Livree, UserId = 2, DeliveryAddressId = 2 },
                new { Id = 3, OrderDate = new DateTime(2025, 9, 17, 13, 15, 0), Status = OrderStatus.EnLivraison, UserId = 3, DeliveryAddressId = 3 },
                new { Id = 4, OrderDate = new DateTime(2025, 9, 18, 20, 30, 0), Status = OrderStatus.EnAttenteLivreur, UserId = 4, DeliveryAddressId = 4 },
                new { Id = 5, OrderDate = new DateTime(2025, 9, 19, 12, 0, 0), Status = OrderStatus.EnCuisine, UserId = 5, DeliveryAddressId = 5 },
                new { Id = 6, OrderDate = new DateTime(2025, 9, 20, 18, 45, 0), Status = OrderStatus.Validee, UserId = 6, DeliveryAddressId = 6 },
                new { Id = 7, OrderDate = new DateTime(2025, 9, 21, 11, 30, 0), DeliveryDate = new DateTime(2025, 9, 21, 12, 30, 0), Status = OrderStatus.Livree, UserId = 7, DeliveryAddressId = 7 },
                new { Id = 8, OrderDate = new DateTime(2025, 9, 22, 19, 15, 0), Status = OrderStatus.EnLivraison, UserId = 8, DeliveryAddressId = 8 },
                new { Id = 9, OrderDate = new DateTime(2025, 9, 23, 13, 0, 0), Status = OrderStatus.EnCuisine, UserId = 9, DeliveryAddressId = 9 },
                new { Id = 10, OrderDate = new DateTime(2025, 9, 24, 20, 0, 0), Status = OrderStatus.Validee, UserId = 10, DeliveryAddressId = 10 },
                new { Id = 11, OrderDate = new DateTime(2025, 9, 25, 12, 45, 0), Status = OrderStatus.EnAttenteLivreur, UserId = 1, DeliveryAddressId = 11 },
                new { Id = 12, OrderDate = new DateTime(2025, 9, 26, 18, 30, 0), DeliveryDate = new DateTime(2025, 9, 26, 19, 20, 0), Status = OrderStatus.Livree, UserId = 2, DeliveryAddressId = 12 }
            );

            // Seed OrderProduct join table
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity(j => j.HasData(
                    // Order 1: Pizza Margherita + Coca-Cola
                    new { OrdersId = 1, ProductsId = 1 },
                    new { OrdersId = 1, ProductsId = 31 },

                    // Order 2: Spaghetti Carbonara + Penne Arrabiata + Eau Minérale
                    new { OrdersId = 2, ProductsId = 11 },
                    new { OrdersId = 2, ProductsId = 12 },
                    new { OrdersId = 2, ProductsId = 36 },

                    // Order 3: Burger Classic + Cheeseburger + Fanta Orange
                    new { OrdersId = 3, ProductsId = 21 },
                    new { OrdersId = 3, ProductsId = 22 },
                    new { OrdersId = 3, ProductsId = 34 },

                    // Order 4: Pizza Regina + Ice Tea Pêche
                    new { OrdersId = 4, ProductsId = 2 },
                    new { OrdersId = 4, ProductsId = 35 },

                    // Order 5: Lasagnes Maison + Sprite
                    new { OrdersId = 5, ProductsId = 18 },
                    new { OrdersId = 5, ProductsId = 33 },

                    // Order 6: Pizza Végétarienne + Burger Végétarien + Jus d'Orange
                    new { OrdersId = 6, ProductsId = 5 },
                    new { OrdersId = 6, ProductsId = 24 },
                    new { OrdersId = 6, ProductsId = 38 },

                    // Order 7: Bacon Burger + BBQ Burger + Coca-Cola Zero
                    new { OrdersId = 7, ProductsId = 23 },
                    new { OrdersId = 7, ProductsId = 26 },
                    new { OrdersId = 7, ProductsId = 32 },

                    // Order 8: Pizza Pepperoni + Limonade
                    new { OrdersId = 8, ProductsId = 4 },
                    new { OrdersId = 8, ProductsId = 39 },

                    // Order 9: Fettuccine Alfredo + Fusilli au Pesto + Eau Pétillante
                    new { OrdersId = 9, ProductsId = 14 },
                    new { OrdersId = 9, ProductsId = 13 },
                    new { OrdersId = 9, ProductsId = 37 },

                    // Order 10: Pizza Quatre Fromages + Thé Glacé Citron
                    new { OrdersId = 10, ProductsId = 3 },
                    new { OrdersId = 10, ProductsId = 40 },

                    // Order 11: Chicken Burger + Fish Burger + Fanta Orange
                    new { OrdersId = 11, ProductsId = 27 },
                    new { OrdersId = 11, ProductsId = 30 },
                    new { OrdersId = 11, ProductsId = 34 },

                    // Order 12: Linguine aux Fruits de Mer + Pizza Napolitaine + Ice Tea Pêche
                    new { OrdersId = 12, ProductsId = 15 },
                    new { OrdersId = 12, ProductsId = 7 },
                    new { OrdersId = 12, ProductsId = 35 }
                ));
        }
    }
}
