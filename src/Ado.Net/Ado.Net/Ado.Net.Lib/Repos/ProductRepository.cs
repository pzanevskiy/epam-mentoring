﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Ado.Net.Lib.Entities;

namespace Ado.Net.Lib.Repos
{
    public class ProductRepository : IRepository<Product>
    {
        private const string SelectQuery = "SELECT * FROM dbo.Product";
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var adapter = new SqlDataAdapter(SelectQuery, connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            var dt = ds.Tables[0];
            var row = dt.NewRow();
            row["Name"] = product.Name;
            row["Description"] = product.Description;
            row["Height"] = product.Height;
            row["Width"] = product.Width;
            row["Length"] = product.Length;
            row["Weight"] = product.Weight;
            dt.Rows.Add(row);

            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public Product Read(int id)
        {
            Product product = null;
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT Id, Name, Description, Weight, Height FROM dbo.Product " +
                        "WHERE Id = @Id";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.HasRows) return null;

            while (reader.Read())
            {
                product = new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Weight = reader.GetInt32(3),
                    Height = reader.GetInt32(4)
                };
            }

            return product;
        }

        public void Update(Product entity, int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var adapter = new SqlDataAdapter(SelectQuery, connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            var dt = ds.Tables[0];
            var row = dt.AsEnumerable().Single(x => x.Field<int>("Id") == id);
            row["Name"] = entity.Name;
            row["Description"] = entity.Description;
            row["Height"] = entity.Height;
            row["Width"] = entity.Width;
            row["Length"] = entity.Length;
            row["Weight"] = entity.Weight;

            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var adapter = new SqlDataAdapter(SelectQuery, connection);
            var ds = new DataSet();
            adapter.Fill(ds);

            var dt = ds.Tables[0];
            var row = dt.AsEnumerable().Single(x => x.Field<int>("Id") == id);
            row.Delete();

            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT Id, Name, Description, Weight, Height, Width, Length FROM dbo.Product";

            var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();

            if (!reader.HasRows) return products;

            while (reader.Read())
            {
                var product = new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Weight = reader.GetInt32(3),
                    Height = reader.GetInt32(4),
                    Width = reader.GetInt32(5),
                    Length = reader.GetInt32(6)
                };

                products.Add(product);
            }

            return products;
        }
    }
}
