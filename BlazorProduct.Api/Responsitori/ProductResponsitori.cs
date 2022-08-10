using BlazorProduct.Api.Models;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorProduct.Api.Responsitori
{
    public class ProductResponsitori : IProductRepository
    {
        private readonly DBProducts _context;

        public ProductResponsitori(DBProducts context)
        {
            _context = context;
        }

        public async Task CreatProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product productdb)
        {
            _context.Remove(productdb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            var ls = await _context.Products.ToListAsync();
            return ls;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task UpdateProduct(ProductUpdate product, Product productdb)
        {
            productdb.Name = product.Name;
            productdb.Description = product.Description;
            productdb.Price = product.Price;
            await _context.SaveChangesAsync();
        }
    }
}
