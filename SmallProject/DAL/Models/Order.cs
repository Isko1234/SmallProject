namespace SmallProject.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double OverAllPrice { get; set; }
        public DateTime Time { get; set; }
        public virtual IList<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
