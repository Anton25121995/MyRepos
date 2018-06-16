
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins;
using TestProject.Core.Interfaces;
using TestProject.Core.Services;
using TestProject.Core.ViewModels;

namespace TestProject.Core
{
    [Preserve(AllMembers = true)]
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();
            Mvx.RegisterType<IDataBaseService, DataBaseService>();
        }
    }
}
