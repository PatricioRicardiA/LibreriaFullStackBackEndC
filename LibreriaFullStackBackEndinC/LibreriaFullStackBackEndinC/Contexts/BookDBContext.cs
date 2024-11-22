using LibreriaFullStackBackEndinC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibreriaFullStackBackEndinC.Contexts
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }
        public DbSet<BookModel> Books { get; set; }
    }
}
