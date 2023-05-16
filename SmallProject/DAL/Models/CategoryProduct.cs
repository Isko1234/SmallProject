namespace SmallProject.DAL.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
