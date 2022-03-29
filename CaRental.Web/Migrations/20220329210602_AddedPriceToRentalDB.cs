using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaRental.Web.Migrations
{
    public partial class AddedPriceToRentalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Rentals",
                type: "DOUBLE(6, 2)",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "RentalPrice",
                table: "Cars",
                type: "DOUBLE(3, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "DOUBLE(4, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rentals");

            migrationBuilder.AlterColumn<byte[]>(
                name: "DateOfBirth",
                table: "Users",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<double>(
                name: "RentalPrice",
                table: "Cars",
                type: "DOUBLE(4, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "DOUBLE(3, 2)");
        }
    }
}
