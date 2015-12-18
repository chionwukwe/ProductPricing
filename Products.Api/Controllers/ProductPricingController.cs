using System.Collections.Generic;
using System.Web.Http;
using Products.Api.Product;

namespace Products.Api.Controllers
{
    public class ProductPricingController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductPricingController()
        {
            _productRepository = new ProductRepository();
            _productRepository.Save("New Co Ltd", new ProductDetails("Small Wongle", 5));
            _productRepository.Save("New Co Ltd", new ProductDetails("Large Wongle", 8));
            _productRepository.Save("New Co Ltd", new ProductDetails("Super Wongle", 12));
            _productRepository.Save("Old Co Ltd", new ProductDetails("Small Wongle", 6));

            _productRepository.Save("Old Co Ltd", new ProductDetails("Large Wongle", 9));
            _productRepository.Save("Old Co Ltd", new ProductDetails("Mini Wongle", 4));
        }
        
        public IEnumerable<string> Get()
        {
            return _productRepository.GetSuppliers();
        }

        public IEnumerable<ProductDetails> Get(string supplierName, string productName = null)
        {
            return _productRepository.GetProductDetails(supplierName, productName);
        }
    }
}