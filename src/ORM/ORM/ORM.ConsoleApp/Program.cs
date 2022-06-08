using System;
using Microsoft.EntityFrameworkCore;
using ORM.Lib.Context;
using ORM.Lib.Entities;
using ORM.Lib.Repositories;

namespace ORM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>()
                .UseSqlServer("Data Source=EPBYGROW0169;Initial Catalog=Shop.DB;Integrated Security=True")
                .Options;

            var context = new ShopDbContext(optionsBuilder);

            var productRepo = new ProductRepository(context);

            var products = productRepo.GetAll();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

            var orderRepo = new OrderRepository(context);

            var orders = orderRepo.GetOrders(status: OrderStatus.Loading);

            foreach (var order in orders)
            {
                Console.WriteLine(order.Id);
            }
        }
    }
}
