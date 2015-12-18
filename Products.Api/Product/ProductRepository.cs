using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Api.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<string, List<ProductDetails>> _productDetails; 
        public ProductRepository()
        {
            _productDetails = new Dictionary<string, List<ProductDetails>>();   
        }

        public IEnumerable<string> GetProducts(string supplierName)
        {
            var result = _productDetails.FirstOrDefault(_ => _.Key.ToLower() == supplierName.ToLower());
            if (result.Key == null) return null;
            return result.Value.Select(_ => _.ProductName);
        }

        public IEnumerable<ProductDetails> GetProductDetails(string supplierName, string productName)
        {
            var result = _productDetails.FirstOrDefault(_ => _.Key.ToLower() == supplierName.ToLower());
            if (result.Key == null) return null;
            if (string.IsNullOrEmpty(productName)) return result.Value;
            return result.Value.Where(_ => _.ProductName.ToLower() == productName.ToLower());
        }

        public IEnumerable<string> GetSuppliers()
        {
            return _productDetails.Keys.Select(_ => _);
        } 

        public void Save(string supplierName, ProductDetails productDetails)
        {
            if (_productDetails.ContainsKey(supplierName))
            {
                _productDetails[supplierName].Add(productDetails);
            }
            
            else _productDetails.Add(supplierName, new List<ProductDetails>{ productDetails});
        }
    }
}