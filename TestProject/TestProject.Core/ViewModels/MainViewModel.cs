using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IMvxNavigationService navigationService, IDataBaseService dataBaseService) : base(navigationService, dataBaseService)
        {
            _dataBaseService = dataBaseService;
            _navigationService = navigationService;
            ShowTableViewModelCommand = new MvxAsyncCommand(async () => { await Task.Delay(500); await _navigationService.Navigate<TableViewModel>(); });
            
            ShowTableViewModelCommand.Execute();
        }
        
        public IMvxAsyncCommand ShowTableViewModelCommand { get; private set; }

        
    }
}
