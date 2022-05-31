using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(x => x.Orders.Length > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.Select(customer => (
                customer,
                suppliers.Where(supplier => supplier.Country == customer.Country &&
                                            supplier.City == customer.City)
            ));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.GroupJoin(suppliers,
                c => (c.Country, c.City),
                s => (s.Country, s.City),
                (customer, supplierGroup) => (customer, supplierGroup)
            );
        }

        // TODO: incorrect task description!!!
        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Length > 0 && c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            return customers.Where(c => c.Orders.Length > 0)
                .Select(customer => (
                    customer,
                    customer.Orders
                        .OrderBy(o => o.OrderDate).First().OrderDate)
                );
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return Linq4(customers)
                .OrderBy(c => c.dateOfEntry.Year)
                .ThenBy(c => c.dateOfEntry.Month)
                .ThenByDescending(c => c.customer.Orders.Sum(order => order.Total))
                .ThenBy(c => c.customer.CustomerID);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            return customers.Where(c => c.PostalCode.Any(ch => !char.IsDigit(ch)) ||
                                        string.IsNullOrEmpty(c.Region) ||
                                        !c.Phone.Contains('('));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            return products.GroupBy(p => p.Category)
                .Select(productGroup => new Linq7CategoryGroup
                {
                    Category = productGroup.Key,
                    UnitsInStockGroup = productGroup.GroupBy(product => product.UnitsInStock)
                        .Select(gr => new Linq7UnitsInStockGroup
                    {
                        UnitsInStock = gr.Key,
                        Prices = gr.Select(product => product.UnitPrice).OrderBy(price => price)
                    })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            return products.Select(p =>
                {
                    if (p.UnitPrice > 0 && p.UnitPrice <= cheap)
                    {
                        return (cheap, product: p);
                    }
                    if (p.UnitPrice > cheap && p.UnitPrice <= middle)
                    {
                        return (middle, product: p);
                    }
                    return (expensive, product: p);
                })
                .GroupBy(gr => gr.Item1)
                .Select(gr => (gr.Key, gr.Select(x => x.product)));
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            return customers.GroupBy(c => c.City)
                .Select(gr => (
                    gr.Key,
                    Convert.ToInt32(gr.Average(c => c.Orders.Sum(o => o.Total))),
                    Convert.ToInt32(gr.Average(c => c.Orders.Length))
                ));
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            return string.Join("",
                suppliers.Select(s => s.Country)
                    .Distinct()
                    .OrderBy(country => country.Length)
                    .ThenBy(country => country));
        }
    }
}