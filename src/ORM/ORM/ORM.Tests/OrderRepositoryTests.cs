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
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Create_Order_InsertsOrder()
        {
            using var context = new ShopDbContext(
                new DbContextOptionsBuilder<ShopDbContext>()
                    .UseInMemoryDatabase("ShopDbContext")
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
    }
}