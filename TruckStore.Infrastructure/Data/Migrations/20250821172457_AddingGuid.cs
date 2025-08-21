using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TruckStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxSpeed = table.Column<int>(type: "int", nullable: false),
                    maxLiftingCapacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_BrandId",
                table: "Trucks",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
