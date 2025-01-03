﻿using Microsoft.EntityFrameworkCore;
using Server.Data.Configurations;
using Server.Entities.Models;

namespace Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfiguration(new ProductConfiguration());

        _ = modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Angular Speedster Board 2000",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 200,
                PictureUrl = "/images/products/sb-ang1.png",
                Category = "Boards",
                Brand = "Angular",
                QuantityInStock = 82
            },
            new Product
            {
                Id = 2,
                Name = "Green Angular Board 3000",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 150,
                PictureUrl = "/images/products/sb-ang2.png",
                Category = "Boards",
                Brand = "Angular",
                QuantityInStock = 75
            },
            new Product
            {
                Id = 3,
                Name = "Core Board Speed Rush 3",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 180,
                PictureUrl = "/images/products/sb-core1.png",
                Category = "Boards",
                Brand = "NetCore",
                QuantityInStock = 3
            },
            new Product
            {
                Id = 4,
                Name = "Net Core Super Board",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 300,
                PictureUrl = "/images/products/sb-core2.png",
                Category = "Boards",
                Brand = "NetCore",
                QuantityInStock = 52
            },
            new Product
            {
                Id = 5,
                Name = "React Board Super Whizzy Fast",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 250,
                PictureUrl = "/images/products/sb-react1.png",
                Category = "Boards",
                Brand = "React",
                QuantityInStock = 97
            },
            new Product
            {
                Id = 6,
                Name = "Typescript Entry Board",
                Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                Price = 120,
                PictureUrl = "/images/products/sb-ts1.png",
                Category = "Boards",
                Brand = "Typescript",
                QuantityInStock = 37
            },
            new Product
            {
                Id = 7,
                Name = "Core Blue Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 10,
                PictureUrl = "/images/products/hat-core1.png",
                Category = "Hats",
                Brand = "NetCore",
                QuantityInStock = 32
            },
            new Product
            {
                Id = 8,
                Name = "Green React Woolen Hat",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 8,
                PictureUrl = "/images/products/hat-react1.png",
                Category = "Hats",
                Brand = "React",
                QuantityInStock = 6
            },
            new Product
            {
                Id = 9,
                Name = "Purple React Woolen Hat",
                Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 15,
                PictureUrl = "/images/products/hat-react2.png",
                Category = "Hats",
                Brand = "React",
                QuantityInStock = 17
            },
            new Product
            {
                Id = 10,
                Name = "Blue Code Gloves",
                Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                Price = 18,
                PictureUrl = "/images/products/glove-code1.png",
                Category = "Gloves",
                Brand = "VS Code",
                QuantityInStock = 74
            },
            new Product
            {
                Id = 11,
                Name = "Green Code Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 15,
                PictureUrl = "/images/products/glove-code2.png",
                Category = "Gloves",
                Brand = "VS Code",
                QuantityInStock = 19
            },
            new Product
            {
                Id = 12,
                Name = "Purple React Gloves",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                Price = 16,
                PictureUrl = "/images/products/glove-react1.png",
                Category = "Gloves",
                Brand = "React",
                QuantityInStock = 77
            },
            new Product
            {
                Id = 13,
                Name = "Green React Gloves",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 14,
                PictureUrl = "/images/products/glove-react2.png",
                Category = "Gloves",
                Brand = "React",
                QuantityInStock = 45
            },
            new Product
            {
                Id = 14,
                Name = "Redis Red Boots",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 250,
                PictureUrl = "/images/products/boot-redis1.png",
                Category = "Boots",
                Brand = "Redis",
                QuantityInStock = 49
            },
            new Product
            {
                Id = 15,
                Name = "Core Red Boots",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 189,
                PictureUrl = "/images/products/boot-core2.png",
                Category = "Boots",
                Brand = "NetCore",
                QuantityInStock = 28
            },
            new Product
            {
                Id = 16,
                Name = "Core Purple Boots",
                Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                Price = 199,
                PictureUrl = "/images/products/boot-core1.png",
                Category = "Boots",
                Brand = "NetCore",
                QuantityInStock = 69
            },
            new Product
            {
                Id = 17,
                Name = "Angular Purple Boots",
                Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                Price = 150,
                PictureUrl = "/images/products/boot-ang2.png",
                Category = "Boots",
                Brand = "Angular",
                QuantityInStock = 35
            },
            new Product
            {
                Id = 18,
                Name = "Angular Blue Boots",
                Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                Price = 180,
                PictureUrl = "/images/products/boot-ang1.png",
                Category = "Boots",
                Brand = "Angular",
                QuantityInStock = 27
            }
        );
    }
}
