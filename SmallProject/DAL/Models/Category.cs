namespace SmallProject.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual IList<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
