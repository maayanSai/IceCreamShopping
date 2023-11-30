namespace IceCreamsShopping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public string Weather { get; set; }
        public string Product { get; set; }
        public string Flavors { get; set; }
        public int OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsHoliday { get; set; }

    }
}
