using System;
using ORM.Dapper.Library.Context;
using ORM.Dapper.Library.Entities;
using ORM.Dapper.Library.Repositories;

namespace ORM.Dapper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=EPBYGROW0169;Initial Catalog=Shop.DB;Integrated Security=True";
            var context = new ShopDbContext(connectionString);

            //var productRepo = new ProductRepository(context);

            //var products = productRepo.GetAllProducts();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Name);
            //}

            var orderRepo = new OrderRepository(context);

            var orderEntity = new Order()
            {
                CreatedDate = DateTime.Now,
                ProductId = 1,
                Status = OrderStatus.Loading,
                UpdateDate = DateTime.Now + TimeSpan.FromHours(5)
            };

            orderRepo.Create(orderEntity);

            //var order = orderRepo.Read(2002);

            //orderEntity.Id = 2002;
            //orderEntity.Status = OrderStatus.NotStarted;
            //orderRepo.Update(orderEntity);

            //orderRepo.Delete(orderEntity);

            var orders = orderRepo.GetAll(productId: 1, status: OrderStatus.Loading);

            foreach (var order in orders)
            {
                Console.WriteLine(order.Id);
            }
        }
    }
}
