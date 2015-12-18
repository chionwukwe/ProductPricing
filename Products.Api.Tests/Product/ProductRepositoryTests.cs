using System.Linq;
using NUnit.Framework;
using Products.Api.Product;

namespace Products.Api.Tests.Product
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _productRepository = new ProductRepository();
            _productRepository.Save("New Co Ltd", new ProductDetails("Small Wongle", 5));
            _productRepository.Save("New Co Ltd", new ProductDetails("Large Wongle", 8));
            _productRepository.Save("Old Co Ltd", new ProductDetails("Large Wongle", 6));
        }

        [Test]
        public void GivenASupplier_ShouldReturnApprpriateProducts()
        {
         
            var results = _productRepository.GetProducts("New Co Ltd");

            Assert.IsTrue(results.Count() == 2);
        }

        [Test]
        public void GivenASupplierAndProductName_ShouldReturnAppropriateProductDetails()
        {
            var results = _productRepository.GetProductDetails("New Co Ltd", "small Wongle");

            Assert.IsTrue(results.First().Price == 5);
        }

        [Test]
        public void GivenASupplierThatDoesNotExist_ShouldReturnNothing()
        {
            var results = _productRepository.GetProducts("testing");

            Assert.IsTrue(results == null);
        }
    }
}
