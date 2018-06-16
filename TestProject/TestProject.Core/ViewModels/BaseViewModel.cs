using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IMvxNavigationService _navigationService;
        protected static IDataBaseService _dataBaseService;

        protected BaseViewModel(IMvxNavigationService navigationService, IDataBaseService dataBaseService)
        {
            _navigationService = navigationService;
            _dataBaseService = dataBaseService;
        }
    }
}
