using Library.BLL.Interfaces;
using Library.BLL.Services;
using Ninject.Modules;

namespace Library.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}