using Library.DAL.Entities;
using System.Collections.Generic;

namespace Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
