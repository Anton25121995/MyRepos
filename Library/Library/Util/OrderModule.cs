using Ninject.Modules;
using Library.BLL.Interfaces;
using Library.BLL.Services;

namespace Library.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}