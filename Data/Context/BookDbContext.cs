using Microsoft.EntityFrameworkCore;
using TestJulius2Grow.Api.Data.Models;

namespace TestJulius2Grow.Api.Data.Context
{
    public class BookDbContext : DbContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
