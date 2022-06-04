using System;
using Ado.Net.Lib;
using Ado.Net.Lib.Entities;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=EPBYGROW0169;Initial Catalog=Shop.DB;Integrated Security=True";

            var unitOfWork = new UnitOfWork(connectionString);

            unitOfWork.Products.Update(new Product()
            {
                Name = "new product11",
                Description = "product description11",
                Height = 100,
                Length = 200,
                Weight = 300,
                Width = 400
            }, 7);

            unitOfWork.Products.Delete(7);
            //unitOfWork.Orders.Create(new Order
            //{
            //    Status = OrderStatus.NotStarted,
            //    CreatedDate = new DateTime(2022, 06, 04),
            //    UpdatedDate = new DateTime(2022, 06, 05),
            //    ProductId = 1
            //});

            //unitOfWork.Orders.Update(new Order()
            //{
            //    Status = OrderStatus.Cancelled,
            //    CreatedDate = new DateTime(2022, 06, 04),
            //    UpdatedDate = DateTime.Now
            //}, 1);

            //unitOfWork.Orders.Delete(month: 5);

            //var products = unitOfWork.Products.GetAll();
        }
    }
}
