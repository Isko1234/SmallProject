using Microsoft.EntityFrameworkCore;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        #region async-methods

        #region Get
        public async Task<IEnumerable<CategoryProduct>> GetCategoryProducts()
        {
            return await _context.CategoryProducts
                .Include(x => x.Product)
                .Include(x => x.Category).ToListAsync() ;
        }
        public async Task<CategoryProduct> GetCategoryProductByProductId(int id)
        {
            return await _context.CategoryProducts
                .Include(x => x.Product)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ProductId.Equals(id));
        }

        public async Task<CategoryProduct> GetCategoryProductByCategoryId(int id)
        {
            return await _context.CategoryProducts
                .Include(x => x.Product)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.CategoryId.Equals(id));
        }
        #endregion
        #region Add
        public async Task<int> AddCategoryProduct(CategoryProduct CategoryProduct)
        {
            _context.Add(CategoryProduct);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddCategoryProducts(IEnumerable<CategoryProduct> CategoryProducts)
        {
            _context.AddRange(CategoryProducts);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task<int> UpdateCategoryProduct(CategoryProduct CategoryProduct)
        {
            _context.Update(CategoryProduct);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateCategoryProducts(IEnumerable<CategoryProduct> categories)
        {
            _context.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Remove
        public async Task<int> RemoveCategoryProduct(CategoryProduct CategoryProduct)
        {
            _context.Remove(CategoryProduct);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCategoryProducts(IEnumerable<CategoryProduct> categories)
        {
            _context.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
