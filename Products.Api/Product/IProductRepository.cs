using System.Collections.Generic;


namespace Products.Api.Product
{
    public interface IProductRepository
    {
        IEnumerable<string> GetProducts(string supplierName);
        IEnumerable<ProductDetails> GetProductDetails(string supplierName, string productName);
        IEnumerable<string> GetSuppliers();
        void Save(string supplierName, ProductDetails productDetails);
    }
}
