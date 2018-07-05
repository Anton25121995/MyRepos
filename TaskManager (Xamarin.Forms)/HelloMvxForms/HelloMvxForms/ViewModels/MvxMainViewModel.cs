using HelloMvxForms.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;

namespace HelloMvxForms.Core.ViewModels
{
    public class MvxMainViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        
        public MvxMainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToLoginCommand = new MvxAsyncCommand(NavigateToLogin);
            NavigateToLoginCommand.Execute();
        }
        
        public override Task Initialize()
        {
            return base.Initialize();
        }

        private async Task NavigateToLogin()
        {
            await _navigationService.Navigate<LoginViewModel>();
        }
        
        public IMvxCommand NavigateToLoginCommand { get; private set; }

    }
}