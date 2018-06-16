using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TestProject.Core.ViewModels;
using TestProject.iOS.ViewControllers.Base;

namespace TestProject.iOS.ViewControllers.Main
{
    [MvxRootPresentation]
    public partial class MainViewController : BaseViewController<MainViewModel>
    {
        public MainViewController() : base("MainViewController", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Apply();
        }
    }
}
