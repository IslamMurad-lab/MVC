using ProductMVC.Models;

namespace ProductMVC.Models
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Smart Watch",
                Price = 2500,
                ImageUrl = "/assets/smartwatch.jfif"
            },

            new Product
            {
                Id = 2,
                Name = "Phone",
                Price = 15000,
                ImageUrl = "/assets/phone.jfif"
            },

            new Product
            {
                Id = 3,
                Name = "PC",
                Price = 30000,
                ImageUrl = "/assets/PC.jfif"
            }
        };

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void AddNewProduct(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.ImageUrl = product.ImageUrl;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}