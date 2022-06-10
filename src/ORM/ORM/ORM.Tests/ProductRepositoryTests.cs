using System;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ORM.Lib.Context;
using ORM.Lib.Entities;
using ORM.Lib.Repositories;

namespace ORM.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void Create_Product_InsertsProduct()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext1")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Product
            {
                Id = 1,
                Name = "product",
                Description = "description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            };

            var productRepository = new ProductRepository(context);

            productRepository.Create(new Product
            {
                Name = "product",
                Description = "description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            });

            var product = context.Product.Single();

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(product));
        }

        [Test]
        public void Delete_Product_DeletesProduct()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext2")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Product
            {
                Id = 1,
                Name = "product",
                Description = "description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            };

            context.Product.Add(expected);
            context.SaveChanges();

            var productRepository = new ProductRepository(context);

            productRepository.Delete(expected);

            var actualCount = context.Product.Count();

            var expectedCount = 0;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Update_Product_UpdatesProduct()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext3")
                    .Options);
            context.Database.EnsureDeleted();

            var product = new Product
            {
                Id = 1,
                Name = "product",
                Description = "description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            };

            context.Product.Add(product);
            context.SaveChanges();


            var productRepository = new ProductRepository(context);
            var expected = context.Product.Single();
            expected.Name = "new name";
            expected.Description = "new desc";

            productRepository.Update(expected);

            var actualProduct = context.Product.Single();

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actualProduct));
        }

        [Test]
        public void Read_Product_ReturnsProduct()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext4")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Product
            {
                Id = 1,
                Name = "product",
                Description = "description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            };

            context.Product.Add(expected);
            context.SaveChanges();

            var productRepository = new ProductRepository(context);

            var actualOrder = productRepository.Read(1);

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actualOrder));
        }
    }
}