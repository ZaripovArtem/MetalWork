using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().HasData(
                new Material[]
                {
                    new Material {Id = 1, Name = "Железо", Price = 400},
                    new Material {Id = 2, Name = "Аллюминий", Price = 800},
                    new Material {Id = 3, Name = "Чугун", Price = 1000}
                });

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product {Id = 1, Name = "Забор", Price = 5000},
                    new Product {Id = 2, Name = "Калитка", Price = 3000}
                });

            modelBuilder.Entity<ProductComposition>().HasData(
                new ProductComposition[]
                {
                    new ProductComposition {Id = 1, ProductId = 1, MaterialId = 1, Count = 2},
                    new ProductComposition {Id = 2, ProductId = 1, MaterialId = 2, Count = 2},
                    new ProductComposition {Id = 3, ProductId = 2, MaterialId = 2, Count = 2},
                    new ProductComposition {Id = 4, ProductId = 2, MaterialId = 3, Count = 1}
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer[]
                {
                    new Customer {Id = 1, Surname = "Лебедев", Name = "Андрей", Patronomic = "Никитевич", Address = "Пушкина, 12", Email = "a.Lebed51@gmail.com"},
                    new Customer {Id = 2, Surname = "Попов", Name = "Марк", Patronomic = "Александрович", Address = "Еники, 5", Email = "markqwe1@gmail.com"},
                    new Customer {Id = 3, Surname = "Иванов", Name = "Владимир", Patronomic = "Тимурович", Address = "Амирхана, 3", Email = "vovaTim@mail.ru"},
                    new Customer {Id = 4, Surname = "Пестов", Name = "Евгений", Patronomic = "Федорович", Address = "Попова, 76", Email = "evgeniypestov2001@yandex.ru"}
                });

            modelBuilder.Entity<Sell>().HasData(
                new Sell[]
                {
                    new Sell {Id = 1, Date = DateTime.Now, CustomerId = 1, ProductId = 1, Count = 10},
                    new Sell {Id = 2, Date = DateTime.Now, CustomerId = 3, ProductId = 2, Count = 2}
                });
        }
    }
}
