using System.Collections.Generic;
using System.Data.SqlClient;
using Ado.Net.Lib.Entities;

namespace Ado.Net.Lib.Repos
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "INSERT INTO dbo.Product " +
                        "(Name, Description, Weight, Height, Width, Length) " +
                        "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Weight", product.Weight);
            command.Parameters.AddWithValue("@Height", product.Height);
            command.Parameters.AddWithValue("@Width", product.Width);
            command.Parameters.AddWithValue("@Length", product.Length);
            command.ExecuteNonQuery();
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
            var query = "UPDATE dbo.Product " +
                        "SET Name = @Name, " +
                        "Description = @Description, " +
                        "Weight = @Weight, " +
                        "Height = @Height, " +
                        "Width = @Width, " +
                        "Length = @Length " +
                        "WHERE Id = @Id";
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Description", entity.Description);
            command.Parameters.AddWithValue("@Weight", entity.Weight);
            command.Parameters.AddWithValue("@Height", entity.Height);
            command.Parameters.AddWithValue("@Width", entity.Width);
            command.Parameters.AddWithValue("@Length", entity.Length);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "DELETE FROM dbo.Product WHERE Id = @Id";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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
