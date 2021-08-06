using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CodingInterview.Databases
{
    [ExcludeFromCodeCoverage]
    public class SqliteDatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }

        public SqliteDatabaseContext() : base(Options())
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<SqliteDatabaseContext> Options()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            return new DbContextOptionsBuilder<SqliteDatabaseContext>().UseSqlite(connection).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Seattle Cider Company",
                    Type = "Brewery"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Cicatriz",
                    Type = "Cafe"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Second Harvest",
                    Type = "Food Bank"
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Apple",
                    Type = "Produce",
                    Unit = "lbs",
                    Price = 1.63,
                    Taxes = 0.065
                }, new Item
                {
                    Id = 2,
                    Name = "Chocolate Bar",
                    Type = "Candy",
                    Unit = "bar",
                    Price = 3.99,
                    Taxes = 0.065
                }, new Item
                {
                    Id = 3,
                    Name = "Huitlacoche",
                    Type = "Canned",
                    Unit = "can",
                    Price = 27.99,
                    Taxes = 0.065
                });

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    CustomerId = 1,
                    Created = DateTime.UtcNow.AddDays(-65),
                    Paid = DateTime.UtcNow.AddDays(-48),
                    Shipped = DateTime.UtcNow.AddDays(-40)
                },
                new Invoice
                {
                    Id = 2,
                    CustomerId = 1,
                    Created = DateTime.UtcNow.AddDays(-56),
                    Paid = DateTime.UtcNow.AddDays(-48),
                    Shipped = DateTime.UtcNow.AddDays(-40)
                },
                new Invoice
                {
                    Id = 3,
                    CustomerId = 1,
                    Created = DateTime.UtcNow.AddDays(-45),
                    Paid = DateTime.UtcNow.AddDays(-38),
                    Shipped = DateTime.UtcNow.AddDays(-30)
                },
                new Invoice
                {
                    Id = 4,
                    CustomerId = 2,
                    Created = DateTime.UtcNow.AddDays(-21),
                    Paid = DateTime.UtcNow.AddDays(-15)
                },
                new Invoice
                {
                    Id = 5,
                    CustomerId = 2,
                    Created = DateTime.UtcNow.AddDays(-10)
                },
                new Invoice
                {
                    Id = 6,
                    CustomerId = 3,
                    Created = DateTime.UtcNow.AddDays(-13)
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    InvoiceId = 1,
                    ItemId = 1,
                    Quantity = 100
                },
                new Order
                {
                    Id = 2,
                    InvoiceId = 1,
                    ItemId = 2,
                    Quantity = 15
                },
                new Order
                {
                    Id = 3,
                    InvoiceId = 2,
                    ItemId = 1,
                    Quantity = 20
                },
                new Order
                {
                    Id = 4,
                    InvoiceId = 2,
                    ItemId = 2,
                    Quantity = 20
                },
                new Order
                {
                    Id = 5,
                    InvoiceId = 1,
                    ItemId = 3,
                    Quantity = 5
                },
                new Order
                {
                    Id = 6,
                    InvoiceId = 4,
                    ItemId = 1,
                    Quantity = 500
                },
                new Order
                {
                    Id = 7,
                    InvoiceId = 4,
                    ItemId = 2,
                    Quantity = 50
                },
                new Order
                {
                    Id = 8,
                    InvoiceId = 5,
                    ItemId = 1,
                    Quantity = 20
                },
                new Order
                {
                    Id = 9,
                    InvoiceId = 5,
                    ItemId = 2,
                    Quantity = 20
                },
                new Order
                {
                    Id = 10,
                    InvoiceId = 3,
                    ItemId = 2,
                    Quantity = 20
                },
                new Order
                {
                    Id = 11,
                    InvoiceId = 3,
                    ItemId = 3,
                    Quantity = 5
                },
                new Order
                {
                    Id = 12,
                    InvoiceId = 3,
                    ItemId = 1,
                    Quantity = 500
                },
                new Order
                {
                    Id = 13,
                    InvoiceId = 6,
                    ItemId = 1,
                    Quantity = 20
                },
                new Order
                {
                    Id = 14,
                    InvoiceId = 6,
                    ItemId = 2,
                    Quantity = 20
                },
                new Order
                {
                    Id = 15,
                    InvoiceId = 6,
                    ItemId = 2,
                    Quantity = 20
                });
        }
    }
}
