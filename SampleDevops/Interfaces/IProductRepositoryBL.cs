using SampleDevops.Models;

namespace SampleDevops.Interfaces
{
    public interface IProductRepositoryBL
    {
        List<ProductEntity> GetAllProducts();
        ProductEntity GetProductById(Guid id);
        ProductEntity AddProduct(ProductEntity product);
        ProductEntity DeleteProduct(Guid id);
        bool NotAvailable(Guid id);
    }
}
