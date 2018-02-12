using Library.BLL.DTO;
using Library.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Library.WEB.Models;
using Library.BLL.Infrastructure;

namespace Library.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = orderService.GetBooks();
            //Mapper.Initialize(cfg => cfg.CreateMap<BookDTO, BookViewModel>());
            var books = Mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookDtos);
            return View(books);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                BookDTO book = orderService.GetBook(id);
                Mapper.Initialize(cfg => cfg.CreateMap<BookDTO, OrderViewModel>()
                    .ForMember("BookId", opt => opt.MapFrom(src => src.Id)));
                var order = Mapper.Map<BookDTO, OrderViewModel>(book);
                return View(order);
            }

            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
                var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}