
using BlazorLaboration.Entities;
using BlazorWebAppLaboration.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorLaboration.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price = 109.95,
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                    ImageURL = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
                    Stock = 5
                },
                new Product
                {
                    Id = 2,
                    Name = "Mens Casual Premium Slim Fit T-Shirts",
                    Price = 22.50,
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                    ImageURL = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg",
                    Stock = 7
                },
                new Product
                {
                    Id = 3,
                    Name = "Mens Cotton Jacket",
                    Price = 59.99,
                    Description = "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",
                    ImageURL = "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg",
                    Stock = 5
                },
                new Product
                {
                    Id = 4,
                    Name = "Mens Casual Slim Fit",
                    Price = 15.99,
                    Description = "The color could be slightly different between on the screen and in practice. / Please note that body builds vary by person, therefore, detailed size information should be reviewed below on the product description.",
                    ImageURL = "https://fakestoreapi.com/img/71YXzeOuslL._AC_UY879_.jpg",
                    Stock = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "John Hardy Women's Legends Naga Gold & Silver Dragon Station Chain Bracelet",
                    Price = 695.00,
                    Description = "From our Legends Collection, the Naga was inspired by the mythical water dragon that protects the ocean's pearl. Wear facing inward to be bestowed with love and abundance, or outward for protection.",
                    ImageURL = "https://fakestoreapi.com/img/71pWzhdJNwL._AC_UL640_QL65_ML3_.jpg",
                    Stock = 3
                });
        }
    }
}
