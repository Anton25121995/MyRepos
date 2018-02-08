using System;
using Library.DAL.Entities;

namespace Library.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public int BookId { get; set; }
        public DateTime? Date { get; set; }
    }
}
