using System.Collections.Generic;
using ORM.Dapper.Library.Entities;

namespace ORM.Dapper.Library.Repositories
{
    public interface IExtendedOrderRepository : IRepository<Order>
    {
        void Delete(
            int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null);

        IEnumerable<Order> GetAll(
            int? month = null,
            OrderStatus? status = null,
            int? year = null,
            int? productId = null);
    }
}