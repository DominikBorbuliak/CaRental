﻿// <auto-generated />
using System;
using CaRental.Web.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaRental.Web.Migrations
{
    [DbContext(typeof(CaRentalDBEntities))]
    [Migration("20220329210602_AddedPriceToRentalDB")]
    partial class AddedPriceToRentalDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("CaRental.Web.Database.Models.Car", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("VARCHAR (17)");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("FuelType")
                        .HasColumnType("INT (2)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("VARCHAR (20)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR (20)");

                    b.Property<double>("RentalPrice")
                        .HasColumnType("DOUBLE(3, 2)");

                    b.Property<int>("Type")
                        .HasColumnType("INT (2)");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("INT (4)");

                    b.HasKey("VIN");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CaRental.Web.Database.Models.Rental", b =>
                {
                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.Property<string>("VIN")
                        .HasColumnType("VARCHAR (17)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR (60)");

                    b.Property<double>("Price")
                        .HasColumnType("DOUBLE(6, 2)");

                    b.HasKey("From", "To", "VIN", "Email");

                    b.HasIndex("Email");

                    b.HasIndex("VIN");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CaRental.Web.Database.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR (60)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATETIME");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("BOOLEAN");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR (50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR (43)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR (50)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CaRental.Web.Database.Models.Rental", b =>
                {
                    b.HasOne("CaRental.Web.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaRental.Web.Database.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("VIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
