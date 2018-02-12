using System;

namespace Library.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string Address { get; set; }
        public int BookId { get; set; }
        public DateTime? Date { get; set; }
    }
}
