namespace SmallProject.DAL.DbService
{
    public partial class DbService
    {
        private readonly DatabaseContext _context;

          public DbService(DatabaseContext context)
        {
            _context = context;
        }
    }
}
