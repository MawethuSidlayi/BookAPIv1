using BookAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace BookAPI
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookSubscriptions> BookSubscriptions { get; set; }




    }
}
