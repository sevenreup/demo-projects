using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Entities;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;


        public ProductRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Where(p => true)
                            .ToListAsync();
        }
        public async Task<Product?> GetProduct(string id)
        {
            return await _context
                           .Products
                           .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context
                            .Products
                            .Where(x => x.Name.Equals(name))
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await _context
                            .Products
                            .Where(x => x.Category.Equals(categoryName))
                            .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            var changed = await _context.SaveChangesAsync();

            return changed > 0;
        }
    }
}
