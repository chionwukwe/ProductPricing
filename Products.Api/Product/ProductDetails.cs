

namespace Products.Api.Product
{
    public class ProductDetails
    {
        public ProductDetails(string productName, int price)
        {
            ProductName = productName;
            Price = price;
        }

        public string ProductName { get; private set; }
        public int Price { get; private set; }
        
    }
}