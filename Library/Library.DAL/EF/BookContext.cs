
using System.Data.Entity;
using Library.DAL.Entities;

namespace Library.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        static BookContext()
        {
            Database.SetInitializer<BookContext>(new StoreDbInitializer());
        }
        public BookContext(string connectionString)
            : base(connectionString)
        {
        }
    }


    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });

            base.Seed(db);
            db.SaveChanges();
        }
    }
}
