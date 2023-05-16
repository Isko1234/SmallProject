using Microsoft.EntityFrameworkCore;
using SmallProject.DAL.Models;

namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        #region async-methods
        
        #region Get
        public async Task<IEnumerable<Category>> GetCategorys()
        {
            return await _context.Categories
                 .Include(x => x.CategoryProducts).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategorysByName(string name)
        {
            return await _context.Categories
                .Include(x => x.CategoryProducts)
                .Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories
                .Include(x => x.CategoryProducts)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        #endregion
        #region Add
        public async Task<int> AddCategory(Category category)
        {
            _context.Add(category);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddCategorys(IEnumerable<Category> categorys)
        {
            _context.AddRange(categorys);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task<int> UpdateCategory(Category category)
        {
            _context.Update(category);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateCategorys(IEnumerable<Category> categories)
        {
            _context.UpdateRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #region Remove
        public async Task<int> RemoveCategory(Category category)
        {
            _context.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveCategorys(IEnumerable<Category> categories)
        {
            _context.RemoveRange(categories);
            return await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
