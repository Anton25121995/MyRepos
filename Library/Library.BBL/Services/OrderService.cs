using Library.BLL.DTO;
using Library.BLL.Infrastructure;
using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Library.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(OrderDTO orderDto)
        {
            Book book = Database.Books.Get(orderDto.BookId);

            // валидация
            if (book == null)
                throw new ValidationException("Книга не найдена", "");

            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                BookId = book.Id,
                Sum = book.Price,
            };

            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<Book, BookDTO>());
            return Mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());
        }

        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id книги", "");
            var book = Database.Books.Get(id.Value);

            if (book == null)
                throw new ValidationException("Книга не найдена", "");

            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.Initialize(cfg => cfg.CreateMap<Book, BookDTO>());
            return Mapper.Map<Book, BookDTO>(book);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
