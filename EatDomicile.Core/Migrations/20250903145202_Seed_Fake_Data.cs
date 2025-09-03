using System;
using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Bogus;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;

// ... existing code ...
#nullable disable

namespace EatDomicile.Core.Migrations
{
    public partial class Seed_Fake_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Randomizer.Seed = new Random(20250903);

            int doughCount = 5;
            int drinkCount = 20;
            int burgerCount = 10;
            int pastaCount = 12;
            int pizzaCount = 15;
            int orderCount = 10;

            // 1) Doughs (real type)
            var doughFaker = new AutoFaker<Dough>()
                .RuleFor(d => d.Name, f => f.Commerce.ProductMaterial());
            var doughs = Enumerable.Range(1, doughCount)
                .Select(i =>
                {
                    var d = doughFaker.Generate();
                    d.Id = i; // explicit IDs for deterministic inserts
                    return d;
                })
                .ToList();

            // 2) Products hierarchy (TPT): assign unique IDs across all derived products
            int nextProductId = 1;

            // Drinks (real type)
            var drinkFaker = new AutoFaker<Drink>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(3, 49, 2)))
                .RuleFor(p => p.Fizzy, f => f.Random.Bool())
                .RuleFor(p => p.KCal, f => f.Random.Int(1, 250));
            var drinks = Enumerable.Range(0, drinkCount)
                .Select(_ =>
                {
                    var d = drinkFaker.Generate();
                    d.Id = nextProductId++;
                    return d;
                })
                .ToList();

            // Burgers (real type)
            var burgerFaker = new AutoFaker<Burger>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(5, 29, 2)))
                .RuleFor(p => p.Vegetarien, f => f.Random.Bool());
            var burgers = Enumerable.Range(0, burgerCount)
                .Select(_ =>
                {
                    var b = burgerFaker.Generate();
                    b.Id = nextProductId++;
                    return b;
                })
                .ToList();

            // Pastas (real type)
            var pastaFaker = new AutoFaker<Pasta>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(6, 24, 2)))
                .RuleFor(p => p.Vegetarien, f => f.Random.Bool())
                .RuleFor(p => p.Type, f => f.PickRandom<PastaType>())
                .RuleFor(p => p.KCal, f => f.Random.Int(200, 900));
            var pastas = Enumerable.Range(0, pastaCount)
                .Select(_ =>
                {
                    var p = pastaFaker.Generate();
                    p.Id = nextProductId++;
                    return p;
                })
                .ToList();

            // Pizzas (real type) — Dough navigation filled with an existing Dough
            var pizzaFaker = new AutoFaker<Pizza>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(7, 32, 2)))
                .RuleFor(p => p.Vegetarien, f => f.Random.Bool());
            var rnd = new Random(20250903);
            var pizzas = Enumerable.Range(0, pizzaCount)
                .Select(_ =>
                {
                    var pz = pizzaFaker.Generate();
                    pz.Id = nextProductId++;
                    var pickedDough = doughs[rnd.Next(0, doughs.Count)];
                    pz.Dough = new Dough { Id = pickedDough.Id, Name = pickedDough.Name };
                    return pz;
                })
                .ToList();

            // 3) Orders (real type)
            var orderFaker = new AutoFaker<Order>()
                .RuleFor(o => o.OrderDate, f => f.Date.Between(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow.AddDays(-1)))
                .RuleFor(o => o.DeliveryDate, (f, o) =>
                {
                    if (f.Random.Bool(0.7f))
                        return f.Date.Between(o.OrderDate.AddDays(1), o.OrderDate.AddDays(5));
                    return null;
                })
                .RuleFor(o => o.Status, (f, o) =>
                {
                    if (o.DeliveryDate.HasValue) return OrderStatus.Livree;
                    return f.PickRandom<OrderStatus>();
                });
            var orders = Enumerable.Range(1, orderCount)
                .Select(i =>
                {
                    var o = orderFaker.Generate();
                    o.Id = i;
                    return o;
                })
                .ToList();

            // 4) Prepare InsertData payloads
            // Base Products rows: gather from all derived product instances
            var allProducts = new List<Product>();
            allProducts.AddRange(drinks);
            allProducts.AddRange(burgers);
            allProducts.AddRange(pastas);
            allProducts.AddRange(pizzas);

            // Food base rows (Burgers, Pastas, Pizzas)
            var allFoods = new List<Food>();
            allFoods.AddRange(burgers);
            allFoods.AddRange(pastas);
            allFoods.AddRange(pizzas);

            // 5) Insert Data in relational order

            // Doughs
            migrationBuilder.InsertData(
                table: "Doughs",
                columns: new[] { "Id", "Name" },
                values: To2D(doughs.Select(d => new object[] { d.Id, d.Name })));

            // Products (base)
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: To2D(allProducts.Select(p => new object[] { p.Id, p.Name, p.Price })));

            // Foods (base)
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Vegetarien" },
                values: To2D(allFoods.Select(f => new object[] { f.Id, f.Vegetarien })));

            // Drinks
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Fizzy", "KCal" },
                values: To2D(drinks.Select(d => new object[] { d.Id, d.Fizzy, d.KCal })));

            // Burgers
            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id" },
                values: To2D(burgers.Select(b => new object[] { b.Id })));

            // Pastas
            migrationBuilder.InsertData(
                table: "Pastas",
                columns: new[] { "Id", "Type", "Kcal" },
                values: To2D(pastas.Select(p => new object[] { p.Id, (int)p.Type, p.KCal })));

            // Pizzas
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "DoughId" },
                values: To2D(pizzas.Select(p => new object[] { p.Id, p.Dough.Id })));

            // Orders
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "DeliveryDate", "Status" },
                values: To2D(orders.Select(o => new object[] { o.Id, o.OrderDate, (object?)o.DeliveryDate ?? DBNull.Value, (int)o.Status })));

            // OrderProduct (many-to-many) — attach 1–4 random products per order
            var allProductIds = allProducts.Select(p => p.Id).ToList();
            var orderProductPairs = new List<(int OrderId, int ProductId)>();
            foreach (var order in orders)
            {
                var pick = rnd.Next(1, 5);
                var selected = allProductIds.OrderBy(_ => rnd.Next()).Take(pick);
                foreach (var pid in selected)
                    orderProductPairs.Add((order.Id, pid));
            }
            orderProductPairs = orderProductPairs.Distinct().ToList();

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrdersId", "ProductsId" },
                values: To2D(orderProductPairs.Select(op => new object[] { op.OrderId, op.ProductId })));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            Randomizer.Seed = new Random(20250903);

            int doughCount = 5;
            int drinkCount = 20;
            int burgerCount = 10;
            int pastaCount = 12;
            int pizzaCount = 15;
            int orderCount = 10;

            var doughIds = Enumerable.Range(1, doughCount).ToList();

            int nextProductId = 1;
            var drinkIds = Enumerable.Range(nextProductId, drinkCount).ToList();
            nextProductId += drinkCount;
            var burgerIds = Enumerable.Range(nextProductId, burgerCount).ToList();
            nextProductId += burgerCount;
            var pastaIds = Enumerable.Range(nextProductId, pastaCount).ToList();
            nextProductId += pastaCount;
            var pizzaIds = Enumerable.Range(nextProductId, pizzaCount).ToList();
            nextProductId += pizzaCount;

            var foodIds = burgerIds.Concat(pastaIds).Concat(pizzaIds).ToList();
            var productIds = drinkIds.Concat(foodIds).ToList();

            var orderIds = Enumerable.Range(1, orderCount).ToList();

            var allProductIds = productIds.ToList();
            var orderProductPairs = new List<(int OrderId, int ProductId)>();
            var rnd = new Random(20250903);
            foreach (var oid in orderIds)
            {
                var pick = rnd.Next(1, 5);
                var selected = allProductIds.OrderBy(_ => rnd.Next()).Take(pick);
                foreach (var pid in selected)
                    orderProductPairs.Add((oid, pid));
            }
            orderProductPairs = orderProductPairs.Distinct().ToList();

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: To2D(orderProductPairs.Select(x => new object[] { x.OrderId, x.ProductId })));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValues: orderIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValues: pizzaIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValues: pastaIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValues: burgerIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValues: drinkIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValues: foodIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValues: productIds.Cast<object>().ToArray());

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValues: doughIds.Cast<object>().ToArray());
        }

        private static object[,] To2D(IEnumerable<object[]> rows)
        {
            var list = rows.ToList();
            var cols = list.FirstOrDefault()?.Length ?? 0;
            var result = new object[list.Count, cols];
            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = list[i][j] ?? DBNull.Value;
            return result;
        }
    }
}