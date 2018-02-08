using System;
using System.Collections.Generic;
using System.Linq;
using Library.DAL.Entities;
using Library.DAL.EF;
using Library.DAL.Interfaces;
using System.Data.Entity;

namespace Library.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private BookContext db;

        public OrderRepository(BookContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Book);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Book).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
