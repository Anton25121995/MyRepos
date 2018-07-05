using HelloMvxForms.Core.ViewModels;
using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace HelloMvxForms.Core
{
    public class MvxApp : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterNavigationServiceAppStart<LoginViewModel>();

            Mvx.Resolve<IDataBaseService<User>>();
            Mvx.Resolve<IDataBaseService<Item>>();
        }
    }
}