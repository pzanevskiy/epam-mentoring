﻿using System;
using System.Collections.Generic;
using Dapper;
using ORM.Dapper.Library.Context;
using ORM.Dapper.Library.Entities;

namespace ORM.Dapper.Library.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            using var connection = _context.CreateConnection();

            var query = "INSERT INTO Product (Name, Description, Weight, Height, Width, Length) " +
                        "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

            connection.Execute(query, entity);
        }

        public Product Read(int id)
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Product WHERE Id = @Id";

            return connection.QueryFirst<Product>(query, new { Id = id });
        }

        public void Update(Product entity)
        {
            using var connection = _context.CreateConnection();

            var query = "UPDATE Product " +
                        "SET Name = @Name, " +
                        "Description = @Description, " +
                        "Weight =  @Weight, " +
                        "Height = @Height, " +
                        "Width = @Width, " +
                        "Length = @Length " +
                        "WHERE Id = @Id";

            connection.Execute(query, entity);
        }

        public void Delete(Product entity)
        {
            using var connection = _context.CreateConnection();

            var query = "DELETE FROM Product WHERE Id = @ID";

            connection.Execute(query, entity);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Product";

            return connection.Query<Product>(query);
        }
    }
}
