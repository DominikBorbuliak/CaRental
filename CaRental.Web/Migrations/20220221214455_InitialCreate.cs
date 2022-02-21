using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaRental.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "VARCHAR (17)", nullable: false),
                    Manufacturer = table.Column<string>(type: "VARCHAR (20)", nullable: false),
                    Model = table.Column<string>(type: "VARCHAR (20)", nullable: false),
                    Type = table.Column<int>(type: "INT (2)", nullable: false),
                    FuelType = table.Column<int>(type: "INT (2)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfManufacture = table.Column<int>(type: "INT (4)", nullable: false),
                    RentalPrice = table.Column<double>(type: "DOUBLE(4, 2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "VARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "VARCHAR (60)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    Surname = table.Column<string>(type: "VARCHAR (50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR (43)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    From = table.Column<DateTime>(type: "TEXT", nullable: false),
                    To = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VIN = table.Column<string>(type: "VARCHAR (17)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR (60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => new { x.From, x.To, x.VIN, x.Email });
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_VIN",
                        column: x => x.VIN,
                        principalTable: "Cars",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_Email",
                        column: x => x.Email,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_Email",
                table: "Rentals",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_VIN",
                table: "Rentals",
                column: "VIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
