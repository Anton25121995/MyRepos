using System.Data.Entity;

namespace Library.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }



    }
}