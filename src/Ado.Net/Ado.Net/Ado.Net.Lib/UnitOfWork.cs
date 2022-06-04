using Ado.Net.Lib.Entities;
using Ado.Net.Lib.Repos;

namespace Ado.Net.Lib
{
    public class UnitOfWork
    {
        private IRepository<Product> _productRepository;
        private IExtendedOrderRepository _orderRepository;

        private readonly string _connectionString;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IRepository<Product> Products
        {
            get
            {
                return _productRepository ??= new ProductRepository(_connectionString);
            }
        }

        public IExtendedOrderRepository Orders
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_connectionString);
            }
        }
    }
}
