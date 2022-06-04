using System;
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
        public void Create_Order_InsertsOrderIntoDb()
        {
            Assert.DoesNotThrow(() => _orderRepository.Create(_order));
        }

        [Test]
        public void Read_ValidId_ReturnsOrder()
        {
            var expectedOrder = _order;
            expectedOrder.Id = 4;
            var actual = _orderRepository.Read(4);

            Assert.AreEqual(JsonSerializer.Serialize(expectedOrder), JsonSerializer.Serialize(actual));
        }

        [Test]
        public void Read_NotValidId_ReturnsNull()
        {
            var actual = _orderRepository.Read(10);

            Assert.IsNull(actual);
        }

        [Test]
        public void Update_Order_UpdatesOrderIntoDb()
        {
            var expectedOrder = _order;
            expectedOrder.Id = 4;
            expectedOrder.UpdatedDate = _order.UpdatedDate + TimeSpan.FromHours(4);

            _orderRepository.Update(expectedOrder, 4);
            var actual = _orderRepository.Read(4);

            Assert.AreEqual(JsonSerializer.Serialize(expectedOrder), JsonSerializer.Serialize(actual));
        }

        [Test]
        public void Delete_ValidId_DeletesOrderFromDb()
        {
            _orderRepository.Delete(id: 4);

            var actual = _orderRepository.Read(4);

            Assert.IsNull(actual);
        }
    }
}
