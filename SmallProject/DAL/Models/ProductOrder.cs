namespace SmallProject.DAL.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantiti { get; set; }

        public virtual Product Product { get; set; } = new Product();
        public virtual Order Order { get; set; } = new Order();
    }
}
