namespace SmallProject.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }

        public virtual IList<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();

        public virtual IList<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
