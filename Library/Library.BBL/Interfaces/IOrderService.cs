using Library.BLL.DTO;
using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBooks();
        void Dispose();
    }
}
