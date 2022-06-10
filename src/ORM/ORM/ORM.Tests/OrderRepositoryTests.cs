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
    public class OrderRepositoryTests
    {
        [Test]
        public void Create_Order_InsertsOrder()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext1")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Order
            {
                Id = 1,
                CreatedDate = new DateTime(2022, 6, 9),
                Status = OrderStatus.Arrived,
                UpdateDate = new DateTime(2022, 6, 9, 1, 0, 0)
            };

            var orderRepo = new OrderRepository(context);

            orderRepo.Create(new Order
            {
                CreatedDate = new DateTime(2022, 6, 9),
                Status = OrderStatus.Arrived,
                UpdateDate = new DateTime(2022, 6, 9, 1, 0, 0)
            });

            var order = context.Order.Single();

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(order));
        }

        [Test]
        public void Delete_Order_DeletesOrder()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext2")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Order
            {
                Id = 1,
                CreatedDate = new DateTime(2022, 6, 9),
                Status = OrderStatus.Arrived,
                UpdateDate = new DateTime(2022, 6, 9, 1, 0, 0)
            };

            context.Order.Add(expected);
            context.SaveChanges();

            var orderRepo = new OrderRepository(context);

            orderRepo.Delete(expected);

            var actualCount = context.Order.Count();

            var expectedCount = 0;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Update_Order_UpdatesOrder()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext3")
                    .Options);
            context.Database.EnsureDeleted();

            var order = new Order
            {
                CreatedDate = new DateTime(2022, 6, 9),
                Status = OrderStatus.Arrived,
                UpdateDate = new DateTime(2022, 6, 9, 1, 0, 0)
            };

            context.Order.Add(order);
            context.SaveChanges();


            var orderRepo = new OrderRepository(context);
            var expected = context.Order.Single();
            expected.Status = OrderStatus.Loading;

            orderRepo.Update(expected);

            var actualOrder = context.Order.Single();

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actualOrder));
        }

        [Test]
        public void Read_Order_ReturnsOrder()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext4")
                    .Options);
            context.Database.EnsureDeleted();

            var expected = new Order
            {
                Id = 1,
                CreatedDate = new DateTime(2022, 6, 9),
                Status = OrderStatus.Loading,
                UpdateDate = new DateTime(2022, 6, 9, 1, 0, 0)
            };

            context.Order.Add(expected);
            context.SaveChanges();

            var orderRepo = new OrderRepository(context);

            var actualOrder = orderRepo.Read(1);

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actualOrder));
        }
    }
}