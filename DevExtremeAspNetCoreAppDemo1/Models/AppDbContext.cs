using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreAppDemo1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(e => e.Id);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(e => e.Customers)
                .WithMany(e => e.Orders).HasForeignKey(e => e.CustomerId).IsRequired();
            });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John",
                    Gender = "Male",
                    Phone = 5555551234,
                    Address = "Street 1",
                    City = "New York",
                    Country = "United States"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Smith",
                    Gender = "Male",
                    Phone = 5555551235,
                    Address = "Street 2",
                    City = "Dallas",
                    Country = "United Kingdom"
                }
                );

            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                        OrderId = 10,
                        CustomerId = 1,
                        NumberOfItems = 6,
                        TotalPrice = 500,
                        PaymentStatus = "Paid"
                    },
                    new Order
                    {
                        OrderId = 11,
                        CustomerId = 2,
                        NumberOfItems = 9,
                        TotalPrice = 800,
                        PaymentStatus = "Pending"
                    }
                );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    Username = "admin1",
                    Password = "admin1",
                    Name = "James",
                    Phone = 11230001,
                    Email = "james@custorderpro.com"
            });
        }
    }
    
}
