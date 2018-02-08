using System;

namespace Library.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime Date { get; set; }
    }
}
