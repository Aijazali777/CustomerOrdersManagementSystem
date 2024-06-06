﻿// <auto-generated />
using DevExtremeAspNetCoreAppDemo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevExtremeAspNetCoreAppDemo1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240606074310_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevExtremeAspNetCoreAppDemo1.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.Property<double>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new { Id = 1, Address = "Street 1", City = "New York", Country = "United States", Gender = "Male", Name = "John", Phone = 5555551234.0 },
                        new { Id = 2, Address = "Street 2", City = "Dallas", Country = "United Kingdom", Gender = "Male", Name = "Smith", Phone = 5555551235.0 }
                    );
                });

            modelBuilder.Entity("DevExtremeAspNetCoreAppDemo1.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<int>("NumberOfItems");

                    b.Property<string>("PaymentStatus");

                    b.Property<double>("TotalPrice");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { OrderId = 10, CustomerId = 1, NumberOfItems = 6, PaymentStatus = "Paid", TotalPrice = 500.0 },
                        new { OrderId = 11, CustomerId = 2, NumberOfItems = 9, PaymentStatus = "Pending", TotalPrice = 800.0 }
                    );
                });

            modelBuilder.Entity("DevExtremeAspNetCoreAppDemo1.Models.Order", b =>
                {
                    b.HasOne("DevExtremeAspNetCoreAppDemo1.Models.Customer", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
