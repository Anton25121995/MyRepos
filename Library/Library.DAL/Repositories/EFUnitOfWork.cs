using System;
using Library.DAL.EF;
using Library.DAL.Entities;
using Library.DAL.Interfaces;

namespace Library.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LibraryContext db;
        private BookRepository bookRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new LibraryContext(connectionString);
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
