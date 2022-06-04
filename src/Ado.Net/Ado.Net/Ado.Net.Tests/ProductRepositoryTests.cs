using System.Text.Json;
using Ado.Net.Lib.Entities;
using Ado.Net.Lib.Repos;
using NUnit.Framework;

namespace Ado.Net.Tests
{
    // TODO: make tests isolated!
    public class ProductRepositoryTests
    {
        private const string ConnectionString = "Data Source=EPBYGROW0169;Initial Catalog=Shop.DB;Integrated Security=True";
        private IRepository<Product> _productRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository(ConnectionString);
        }

        [Test]
        public void Create_Product_InsertsProductIntoDB()
        {
            var product = new Product
            {
                Name = "new product",
                Description = "product description",
                Height = 10,
                Length = 20,
                Weight = 30,
                Width = 40
            };

            Assert.DoesNotThrow(() => _productRepository.Create(product));
        }

        [Test]
        public void Read_ValidId_ReturnsProduct()
        {
            var expectedProduct = new Product()
            {
                Id = 1,
                Name = "Cherry",
                Description = "Some description",
                Height = 4,
                Weight = 10,
            };

            var actual = _productRepository.Read(1);

            Assert.AreEqual(JsonSerializer.Serialize(expectedProduct), JsonSerializer.Serialize(actual));
        }

        [Test]
        public void Read_NotValidId_ReturnsNull()
        {
            var actual = _productRepository.Read(2);

            Assert.IsNull(actual);
        }

        [Test]
        public void Update_Product_UpdateProductInDB()
        {
            var expectedProduct = new Product()
            {
                Id = 1,
                Name = "new Cherry",
                Description = "Some description",
                Height = 4,
                Weight = 10,
            };

            _productRepository.Update(expectedProduct, 1);

            var actual = _productRepository.Read(1);

            Assert.AreEqual(JsonSerializer.Serialize(expectedProduct), JsonSerializer.Serialize(actual));
        }

        [Test]
        public void Delete_ValidId_DeleteProductInDB()
        {
            _productRepository.Delete(5);

            var actual = _productRepository.Read(5);

            Assert.IsNull(actual);
        }
    }
}
