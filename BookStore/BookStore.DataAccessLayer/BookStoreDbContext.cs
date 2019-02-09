using BookStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookStore.DataAccessLayer
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
        int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public BookStoreDbContext() : base("BookStoreDb")
        {
        }

        public static BookStoreDbContext Create()
        {
            return new BookStoreDbContext();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
