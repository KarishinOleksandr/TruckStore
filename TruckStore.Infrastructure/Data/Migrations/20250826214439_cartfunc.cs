using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruckStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class cartfunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("0310acb8-e043-4950-9626-5f27c2c897db"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("1252b355-e2ab-4009-a1a2-7113c2589975"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3fb7a059-648e-4d96-a1ac-f76ab65d9c8d"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("75f9efb7-07fb-4a66-a0d5-e2bb026c54e7"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e89cde87-f6e4-4c1b-88e2-5827a9941867"));

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Trucks_TruckId",
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
                    { new Guid("2684a8e2-7010-49b1-a5ac-9011a4ac451c"), "Volvo" },
                    { new Guid("534b4378-9d34-444e-9d77-2fede04f3b80"), "Mercedes" },
                    { new Guid("b5c96930-725a-489e-8cbd-aad6974823a4"), "Scania" },
                    { new Guid("b9916297-1c95-40f4-8176-5ea7b6f4b3c6"), "Iveco" },
                    { new Guid("bdfa547d-7b74-43df-a49d-611ca7f87146"), "Renault" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TruckId",
                table: "CartItems",
                column: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0310acb8-e043-4950-9626-5f27c2c897db"), "Renault" },
                    { new Guid("1252b355-e2ab-4009-a1a2-7113c2589975"), "Volvo" },
                    { new Guid("3fb7a059-648e-4d96-a1ac-f76ab65d9c8d"), "Mercedes" },
                    { new Guid("75f9efb7-07fb-4a66-a0d5-e2bb026c54e7"), "Iveco" },
                    { new Guid("e89cde87-f6e4-4c1b-88e2-5827a9941867"), "Scania" }
                });
        }
    }
}
