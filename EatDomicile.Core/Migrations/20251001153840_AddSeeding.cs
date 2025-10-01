using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Paris", "France", "Île-de-France", "123 Rue de la Paix", 75001 },
                    { 2, "Lyon", "France", "Auvergne-Rhône-Alpes", "456 Avenue des Champs", 69001 },
                    { 3, "Marseille", "France", "Provence-Alpes-Côte d'Azur", "789 Boulevard Victor Hugo", 13001 },
                    { 4, "Toulouse", "France", "Occitanie", "12 Rue du Commerce", 31000 },
                    { 5, "Nice", "France", "Provence-Alpes-Côte d'Azur", "34 Place de la République", 6000 },
                    { 6, "Nantes", "France", "Pays de la Loire", "56 Rue Saint-Michel", 44000 },
                    { 7, "Strasbourg", "France", "Grand Est", "78 Avenue Jean Jaurès", 67000 },
                    { 8, "Lille", "France", "Hauts-de-France", "90 Rue de la Liberté", 59000 },
                    { 9, "Bordeaux", "France", "Nouvelle-Aquitaine", "11 Boulevard des Allées", 33000 },
                    { 10, "Rennes", "France", "Bretagne", "22 Rue du Marché", 35000 },
                    { 11, "Montpellier", "France", "Occitanie", "33 Avenue de la Gare", 34000 },
                    { 12, "Grenoble", "France", "Auvergne-Rhône-Alpes", "44 Rue des Écoles", 38000 }
                });

            migrationBuilder.InsertData(
                table: "Doughs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pâte Fine" },
                    { 2, "Pâte Épaisse" },
                    { 3, "Pâte Croustillante" },
                    { 4, "Pâte Pan" },
                    { 5, "Pâte aux Céréales" },
                    { 6, "Pâte au Fromage" },
                    { 7, "Pâte Sans Gluten" },
                    { 8, "Pâte à l'Ail" },
                    { 9, "Pâte Napolitaine" },
                    { 10, "Pâte New Yorkaise" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Margherita", 9.90m },
                    { 2, "Regina", 11.50m },
                    { 3, "Quatre Fromages", 12.90m },
                    { 4, "Pepperoni", 11.90m },
                    { 5, "Végétarienne", 10.90m },
                    { 6, "Calzone", 13.50m },
                    { 7, "Napolitaine", 10.50m },
                    { 8, "Sicilienne", 12.50m },
                    { 9, "Paysanne", 11.90m },
                    { 10, "Orientale", 12.90m },
                    { 11, "Spaghetti Carbonara", 10.90m },
                    { 12, "Penne Arrabiata", 9.90m },
                    { 13, "Fusilli au Pesto", 11.50m },
                    { 14, "Fettuccine Alfredo", 12.90m },
                    { 15, "Linguine aux Fruits de Mer", 14.90m },
                    { 16, "Rigatoni Bolognaise", 11.90m },
                    { 17, "Farfalle au Saumon", 13.50m },
                    { 18, "Lasagnes Maison", 12.50m },
                    { 19, "Macaroni au Fromage", 9.50m },
                    { 20, "Penne 4 Fromages", 12.90m },
                    { 21, "Burger Classic", 8.90m },
                    { 22, "Cheeseburger", 9.50m },
                    { 23, "Bacon Burger", 10.90m },
                    { 24, "Burger Végétarien", 9.90m },
                    { 25, "Double Cheese", 12.50m },
                    { 26, "BBQ Burger", 11.50m },
                    { 27, "Chicken Burger", 9.90m },
                    { 28, "Burger Savoyard", 12.90m },
                    { 29, "Burger Italien", 11.90m },
                    { 30, "Fish Burger", 10.50m },
                    { 31, "Coca-Cola", 2.50m },
                    { 32, "Coca-Cola Zero", 2.50m },
                    { 33, "Sprite", 2.50m },
                    { 34, "Fanta Orange", 2.50m },
                    { 35, "Ice Tea Pêche", 2.90m },
                    { 36, "Eau Minérale", 1.50m },
                    { 37, "Eau Pétillante", 1.90m },
                    { 38, "Jus d'Orange", 3.50m },
                    { 39, "Limonade", 2.90m },
                    { 40, "Thé Glacé Citron", 2.90m }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Fizzy", "KCal" },
                values: new object[,]
                {
                    { 31, true, 140 },
                    { 32, true, 0 },
                    { 33, true, 139 },
                    { 34, true, 150 },
                    { 35, false, 120 },
                    { 36, false, 0 },
                    { 37, true, 0 },
                    { 38, false, 110 },
                    { 39, true, 135 },
                    { 40, false, 115 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Vegetarien" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, false },
                    { 3, true },
                    { 4, false },
                    { 5, true },
                    { 6, false },
                    { 7, false },
                    { 8, false },
                    { 9, false },
                    { 10, false },
                    { 11, false },
                    { 12, true },
                    { 13, true },
                    { 14, true },
                    { 15, false },
                    { 16, false },
                    { 17, false },
                    { 18, false },
                    { 19, true },
                    { 20, true },
                    { 21, false },
                    { 22, false },
                    { 23, false },
                    { 24, true },
                    { 25, false },
                    { 26, false },
                    { 27, false },
                    { 28, false },
                    { 29, false },
                    { 30, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "jean.dupont@email.fr", "Jean", "Dupont", "0612345678" },
                    { 2, 2, "marie.martin@email.fr", "Marie", "Martin", "0623456789" },
                    { 3, 3, "pierre.bernard@email.fr", "Pierre", "Bernard", "0634567890" },
                    { 4, 4, "sophie.dubois@email.fr", "Sophie", "Dubois", "0645678901" },
                    { 5, 5, "luc.thomas@email.fr", "Luc", "Thomas", "0656789012" },
                    { 6, 6, "emma.robert@email.fr", "Emma", "Robert", "0667890123" },
                    { 7, 7, "antoine.petit@email.fr", "Antoine", "Petit", "0678901234" },
                    { 8, 8, "julie.richard@email.fr", "Julie", "Richard", "0689012345" },
                    { 9, 9, "nicolas.durand@email.fr", "Nicolas", "Durand", "0690123456" },
                    { 10, 10, "claire.simon@email.fr", "Claire", "Simon", "0601234567" }
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                column: "Id",
                values: new object[]
                {
                    21,
                    22,
                    23,
                    24,
                    25,
                    26,
                    27,
                    28,
                    29,
                    30
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DeliveryAddressId", "DeliveryDate", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 2, 2, new DateTime(2025, 9, 16, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 3, 3, null, new DateTime(2025, 9, 17, 13, 15, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, 4, null, new DateTime(2025, 9, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 5, 5, null, new DateTime(2025, 9, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, 6, null, new DateTime(2025, 9, 20, 18, 45, 0, 0, DateTimeKind.Unspecified), 0, 6 },
                    { 7, 7, new DateTime(2025, 9, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 21, 11, 30, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 8, 8, null, new DateTime(2025, 9, 22, 19, 15, 0, 0, DateTimeKind.Unspecified), 3, 8 },
                    { 9, 9, null, new DateTime(2025, 9, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 10, 10, null, new DateTime(2025, 9, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), 0, 10 },
                    { 11, 11, null, new DateTime(2025, 9, 25, 12, 45, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 12, 12, new DateTime(2025, 9, 26, 19, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 26, 18, 30, 0, 0, DateTimeKind.Unspecified), 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Pastas",
                columns: new[] { "Id", "Kcal", "Type" },
                values: new object[,]
                {
                    { 11, 450, 0 },
                    { 12, 380, 1 },
                    { 13, 420, 2 },
                    { 14, 520, 3 },
                    { 15, 480, 4 },
                    { 16, 510, 5 },
                    { 17, 490, 6 },
                    { 18, 550, 9 },
                    { 19, 470, 8 },
                    { 20, 530, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "DoughId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 1 },
                    { 6, 4 },
                    { 7, 9 },
                    { 8, 1 },
                    { 9, 2 },
                    { 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Allergene", "BurgerId", "Kcal", "Name", "PizzaId" },
                values: new object[,]
                {
                    { 1, true, 21, 280, "Mozzarella", null },
                    { 2, false, 22, 18, "Tomate", null },
                    { 3, false, 22, 23, "Basilic", null },
                    { 4, false, 22, 145, "Jambon", null },
                    { 5, false, 23, 22, "Champignons", null },
                    { 6, false, 23, 115, "Olives", null },
                    { 7, false, 24, 31, "Poivrons", null },
                    { 8, false, 25, 40, "Oignons", null },
                    { 9, false, 26, 494, "Pepperoni", null },
                    { 10, true, 27, 131, "Anchois", null },
                    { 11, false, 28, 15, "Salade", null },
                    { 12, false, 28, 250, "Steak Haché", null },
                    { 13, false, 29, 541, "Bacon", null },
                    { 14, true, 29, 403, "Cheddar", null },
                    { 15, false, 21, 11, "Cornichons", null },
                    { 16, false, 22, 172, "Sauce BBQ", null },
                    { 17, false, 30, 112, "Sauce Ketchup", null },
                    { 18, true, 30, 680, "Sauce Mayonnaise", null },
                    { 19, false, 30, 165, "Poulet", null },
                    { 20, false, 25, 25, "Roquette", null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrdersId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 31 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 36 },
                    { 3, 21 },
                    { 3, 22 },
                    { 3, 34 },
                    { 4, 2 },
                    { 4, 35 },
                    { 5, 18 },
                    { 5, 33 },
                    { 6, 5 },
                    { 6, 24 },
                    { 6, 38 },
                    { 7, 23 },
                    { 7, 26 },
                    { 7, 32 },
                    { 8, 4 },
                    { 8, 39 },
                    { 9, 13 },
                    { 9, 14 },
                    { 9, 37 },
                    { 10, 3 },
                    { 10, 40 },
                    { 11, 27 },
                    { 11, 30 },
                    { 11, 34 },
                    { 12, 7 },
                    { 12, 15 },
                    { 12, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 1, 31 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 2, 36 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 3, 34 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 4, 35 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 5, 18 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 5, 33 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 6, 24 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 6, 38 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 7, 23 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 7, 26 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 7, 32 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 8, 39 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 9, 14 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 9, 37 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 10, 40 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 11, 27 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 11, 30 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 11, 34 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 12, 15 });

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumns: new[] { "OrdersId", "ProductsId" },
                keyValues: new object[] { 12, 35 });

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pastas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Burgers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doughs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
