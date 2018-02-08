using Library.DAL.Entities;
using System;

namespace Library.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
