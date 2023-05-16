using Microsoft.EntityFrameworkCore;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        #region async-methods

        #region Get
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders
                 .Include(x => x.ProductOrders)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByOverAllPrice(int price)
        {
            return await _context.Orders
                .Include(x => x.ProductOrders)
                .Where(x => x.OverAllPrice.Equals(price)).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(x => x.ProductOrders)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        #endregion
        #region Add
        public async Task<int> AddOrder(Order Order)
        {
            _context.Add(Order);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddOrders(IEnumerable<Order> Orders)
        {
            _context.AddRange(Orders);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task<int> UpdateOrder(Order Order)
        {
            _context.Update(Order);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateOrders(IEnumerable<Order> categories)
        {
            _context.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Remove
        public async Task<int> RemoveOrder(Order Order)
        {
            _context.Remove(Order);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveOrders(IEnumerable<Order> categories)
        {
            _context.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
