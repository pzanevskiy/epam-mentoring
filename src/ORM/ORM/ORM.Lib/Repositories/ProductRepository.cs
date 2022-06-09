using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ORM.Lib.Context;
using ORM.Lib.Entities;

namespace ORM.Lib.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return Context.Product.ToList();
        }
    }
}