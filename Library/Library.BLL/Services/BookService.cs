using Library.DAL.Repositories;
using Library.Entities.Entities;

namespace Library.BLL.Services
{
    public class BookService : BaseService<Book>
    {
        private BookRepository repository;

        public override BaseRepository<Book> Repository
        {
            get { return repository; }
            set { if (repository == null) repository = new BookRepository(); }
        }
    }
}
