using SampleDevops.Interfaces;
using SampleDevops.Models;

namespace SampleDevops.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<ProductEntity> _context = new List<ProductEntity>() { new ProductEntity { ProductId = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Product1", Description = "Product Description", Design = "Modern", Size = 20, Price = 3000 }, new ProductEntity { ProductId = Guid.Parse("11111111-1111-1111-1111-111111111122"), Name = "Product2", Description = "Product Description", Design = "Modern", Size = 20, Price = 3000 } };
        public ProductRepository()
        {

        }
        public ProductEntity AddProduct(ProductEntity product)
        {
            product.ProductId = Guid.NewGuid();
            _context.Add(product);
            return product;
        }

        public ProductEntity DeleteProduct(Guid id)
        {
            var product = _context.FirstOrDefault(x => x.ProductId == id);
            _context.Remove(product);
            return product;
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _context;
        }

        public ProductEntity GetProductById(Guid id)
        {
            var product = _context.FirstOrDefault(x => x.ProductId == id);
            return product;
        }
        public bool NotAvailable(Guid id)
        {
            var product = _context.Find(x => x.ProductId == id);
            if (product == null)
            {
                return true;
            }
            return false;
        }
    }
}
