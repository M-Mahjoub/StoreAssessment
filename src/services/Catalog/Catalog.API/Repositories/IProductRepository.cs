using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product entity);
        Task<bool> UpdateProduct(Product entity);
        Task<bool> DeleteProduct(string id);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductByName(string productName);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
