using System;
using System.Linq;
using System.Text.Json;
using Ado.Net.Lib.Entities;
using Ado.Net.Lib.Repos;
using NUnit.Framework;

namespace Ado.Net.Tests
{
    // TODO: make tests isolated!
    public class OrderRepositoryTests
    {
        private const string ConnectionString = "Data Source=EPBYGROW0169;Initial Catalog=Shop.DB;Integrated Security=True";
        private IExtendedOrderRepository _orderRepository;
        private Order _order;

        [OneTimeSetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository(ConnectionString);
            _order = new Order
            {
                CreatedDate = new DateTime(2022, 6, 4),
                UpdatedDate = new DateTime(2022, 6, 4) + TimeSpan.FromHours(2),
                Status = OrderStatus.Arrived,
                ProductId = 1
            };
        }

        [Test]
        [Order(1)]
        public void Create_Order_InsertsOrderIntoDb()
        {
            var expected = _order;
            _orderRepository.Create(_order);
            var actual = _orderRepository.GetAll().Last();
            expected.Id = actual.Id;
            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(2)]
        public void Read_ValidId_ReturnsOrder()
        {
            var expectedOrder = _order;
            expectedOrder.Id = _orderRepository.GetAll().Last().Id;
            var actual = _orderRepository.Read(expectedOrder.Id);

            Assert.AreEqual(JsonSerializer.Serialize(expectedOrder), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(3)]
        public void Read_NotValidId_ReturnsNull()
        {
            var actual = _orderRepository.Read(10);

            Assert.IsNull(actual);
        }

        [Test]
        [Order(4)]
        public void Update_Order_UpdatesOrderIntoDb()
        {
            var expectedOrder = _order;
            expectedOrder.Id = _orderRepository.GetAll().Last().Id;
            expectedOrder.UpdatedDate = _order.UpdatedDate + TimeSpan.FromHours(4);

            _orderRepository.Update(expectedOrder, expectedOrder.Id);
            var actual = _orderRepository.Read(expectedOrder.Id);

            Assert.AreEqual(JsonSerializer.Serialize(expectedOrder), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(5)]
        public void Delete_ValidId_DeletesOrderFromDb()
        {
            var id = _orderRepository.GetAll().Last().Id;

            _orderRepository.Delete(id: id);

            var actual = _orderRepository.Read(id);

            Assert.IsNull(actual);
        }
    }
}
