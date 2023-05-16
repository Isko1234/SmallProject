using Microsoft.EntityFrameworkCore;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        #region async-methods

        #region Get
        public async Task<IEnumerable<ProductOrder>> GetProductOrders()
        {
            return await _context.ProductOrders
                .Include(x => x.Product)
                .Include(x => x.Order).ToListAsync();
        }
        public async Task<ProductOrder> GetProductOrderByProductId(int id)
        {
            return await _context.ProductOrders
                .Include(x => x.Product)
                .Include(x => x.Order)
                .FirstOrDefaultAsync(x => x.ProductId.Equals(id));
        }

        public async Task<ProductOrder> GetProductOrderByOrderId(int id)
        {
            return await _context.ProductOrders
                .Include(x => x.Product)
                .Include(x => x.Order)
                .FirstOrDefaultAsync(x => x.OrderId.Equals(id));
        }
        #endregion
        #region Add
        public async Task<int> AddProductOrder(ProductOrder ProductOrder)
        {
            _context.Add(ProductOrder);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddProductOrders(IEnumerable<ProductOrder> ProductOrders)
        {
            _context.AddRange(ProductOrders);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task<int> UpdateProductOrder(ProductOrder ProductOrder)
        {
            _context.Update(ProductOrder);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateProductOrders(IEnumerable<ProductOrder> categories)
        {
            _context.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Remove
        public async Task<int> RemoveProductOrder(ProductOrder ProductOrder)
        {
            _context.Remove(ProductOrder);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveProductOrders(IEnumerable<ProductOrder> categories)
        {
            _context.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
