namespace IceCreamsShopping.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Products product { get; set; }
        public Flavors flavors { get; set; }
        public int TotalPrice { get; set; }
    }
}
