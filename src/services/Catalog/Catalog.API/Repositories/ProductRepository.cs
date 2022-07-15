using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task CreateProduct(Product entity)
        {
            await _catalogContext.Products.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Id, id);

            var deleteResult = await _catalogContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext
                                      .Products
                                      .Find(c => c.Id == id)
                                      .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Category, categoryName);

            return await _catalogContext
                                    .Products
                                    .Find(filter)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            var filter = Builders<Product>.Filter.Eq(c => c.Name, productName);
            return await _catalogContext
                                   .Products
                                   .Find(filter)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogContext
                                     .Products
                                     .Find(c => true)
                                     .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product entity)
        {
            var updateResult = await _catalogContext.Products.ReplaceOneAsync(filter: f => f.Id == entity.Id, replacement: entity);

            return updateResult.IsAcknowledged
                     && updateResult.ModifiedCount > 0;
        }
    }
}
