using System.Collections.Generic;
using Ado.Net.Lib.Entities;

namespace Ado.Net.Lib.Repos
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
