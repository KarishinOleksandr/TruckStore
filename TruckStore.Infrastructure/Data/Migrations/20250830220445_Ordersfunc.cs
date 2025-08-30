using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruckStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ordersfunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2684a8e2-7010-49b1-a5ac-9011a4ac451c"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("534b4378-9d34-444e-9d77-2fede04f3b80"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5c96930-725a-489e-8cbd-aad6974823a4"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b9916297-1c95-40f4-8176-5ea7b6f4b3c6"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("bdfa547d-7b74-43df-a49d-611ca7f87146"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2961d58a-6bf0-43c1-97a3-b52b8beedb72"), "Renault" },
                    { new Guid("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"), "Scania" },
                    { new Guid("758f9dc0-a38c-46f4-930f-ca24cd642702"), "Volvo" },
                    { new Guid("8bd2120d-53b7-459c-873a-c59bf48ad7a7"), "Mercedes" },
                    { new Guid("e87d4300-a03c-4e62-860d-d6854a1451d9"), "Iveco" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_TruckId",
                table: "OrderDetails",
                column: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2961d58a-6bf0-43c1-97a3-b52b8beedb72"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3001b08e-8ec3-4b01-bacc-3e8dcb463e29"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("758f9dc0-a38c-46f4-930f-ca24cd642702"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8bd2120d-53b7-459c-873a-c59bf48ad7a7"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e87d4300-a03c-4e62-860d-d6854a1451d9"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2684a8e2-7010-49b1-a5ac-9011a4ac451c"), "Volvo" },
                    { new Guid("534b4378-9d34-444e-9d77-2fede04f3b80"), "Mercedes" },
                    { new Guid("b5c96930-725a-489e-8cbd-aad6974823a4"), "Scania" },
                    { new Guid("b9916297-1c95-40f4-8176-5ea7b6f4b3c6"), "Iveco" },
                    { new Guid("bdfa547d-7b74-43df-a49d-611ca7f87146"), "Renault" }
                });
        }
    }
}
