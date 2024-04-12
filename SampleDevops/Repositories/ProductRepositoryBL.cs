using SampleDevops.Interfaces;
using SampleDevops.Models;

namespace SampleDevops.Repositories
{
    public class ProductRepositoryBL : IProductRepositoryBL
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryBL(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductEntity AddProduct(ProductEntity product)
        {
            return _productRepository.AddProduct(product);
        }

        public ProductEntity DeleteProduct(Guid id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public ProductEntity GetProductById(Guid id)
        {
            return _productRepository.GetProductById(id);
        }
        public bool NotAvailable(Guid id)
        {
            return _productRepository.NotAvailable(id);
        }
    }
}
