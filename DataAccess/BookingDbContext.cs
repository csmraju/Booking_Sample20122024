using BookingSampleApp_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSampleApp_V1.DataAccess
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
    }
}
