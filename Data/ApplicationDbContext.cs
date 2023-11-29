using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Models;

namespace IceCreamsShopping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Products>? Products { get; set; }
        public DbSet<Flavors>? Flavors { get; set; }
        public DbSet<Stores>? Stores { get; set; }
        public DbSet<IceCreamsShopping.Models.Orders>? Order { get; set; }
    }
}