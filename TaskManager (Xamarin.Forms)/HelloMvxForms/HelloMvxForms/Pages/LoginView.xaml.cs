using HelloMvxForms.Core.ViewModels;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;

namespace HelloMvxForms.Core.Views
{
    [MvxNavigationPagePresentation]
    public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        
    }
}
