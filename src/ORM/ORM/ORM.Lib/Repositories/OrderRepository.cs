using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ORM.Lib.Context;
using ORM.Lib.Entities;

namespace ORM.Lib.Repositories
{
    // TODO: review stored procedures
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrders(int? month = null, OrderStatus? status = null, int? year = null,
            int? productId = null)
        {
            var monthParam = new SqlParameter("@month", month);
            var statusParam = new SqlParameter("@status", status);
            var yearParam = new SqlParameter("@year", year);
            var productIdParam = new SqlParameter("@productId", productId);

            return Context.Order.FromSqlRaw("sp_FetchOrders @status, @month, @year, @productId", 
                statusParam, monthParam, yearParam, productIdParam)
                .ToList();
        }

        public void DeleteOrders(int? month = null, OrderStatus? status = null, int? year = null,
            int? productId = null)
        {
            var monthParam = new SqlParameter("@month", month);
            var statusParam = new SqlParameter("@status", status);
            var yearParam = new SqlParameter("@year", year);
            var productIdParam = new SqlParameter("@productId", productId);

            var ordersToDelete = Context.Order.FromSqlRaw("sp_DeleteOrders @status, @month, @year, @productId",
                statusParam, monthParam, yearParam, productIdParam)
                .ToList();

            Context.Order.RemoveRange(ordersToDelete);
            Context.SaveChanges();
        }
    }
}
