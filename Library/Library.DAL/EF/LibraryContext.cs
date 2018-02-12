using Library.DAL.Entities;
using System.Data.Entity;

namespace Library.DAL.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        static LibraryContext()
        {
            Database.SetInitializer<LibraryContext>(new StoreDbInitializer());
        }
        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });
            db.Books.Add(new Book { Name = "Преступление и наказание", Author = "Ф.Достоевский", Price = 200 });
            db.SaveChanges();
        }
    }
}
