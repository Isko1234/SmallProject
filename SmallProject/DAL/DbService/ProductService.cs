using Microsoft.EntityFrameworkCore;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        #region async-methods

        #region Get
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products
                 .Include(x => x.CategoryProducts)
                 .Include(x => x.ProductOrders)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context.Products
                .Include(x => x.CategoryProducts)
                .Include(x => x.ProductOrders)
                .Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                .Include(x => x.CategoryProducts)
                .Include(x => x.ProductOrders)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        #endregion
        #region Add
        public async Task<int> AddProduct(Product Product)
        {
            _context.Add(Product);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddProducts(IEnumerable<Product> Products)
        {
            _context.AddRange(Products);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task<int> UpdateProduct(Product Product)
        {
            _context.Update(Product);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateProducts(IEnumerable<Product> categories)
        {
            _context.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Remove
        public async Task<int> RemoveProduct(Product Product)
        {
            _context.Remove(Product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProducts(IEnumerable<Product> categories)
        {
            _context.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
