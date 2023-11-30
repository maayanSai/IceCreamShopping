using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Models;
using static NuGet.Packaging.PackagingConstants;

namespace IceCreamsShopping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Flavors>? Flavors { get; set; }
        public DbSet<Stores>? Stores { get; set; }
        public DbSet<IceCreamsShopping.Models.Order>? Order { get; set; }


    }
}