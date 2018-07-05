using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using HelloMvxForms.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMvxForms.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IMvxNavigationService _navigationService;
        protected static IDataBaseService<Item> _itemService;
        protected static IDataBaseService<User> _userService;

        protected BaseViewModel(IMvxNavigationService navigationService, IDataBaseService<Item> itemService, IDataBaseService<User> userService)
        {
            _navigationService = navigationService;
            _itemService = itemService;
            _userService = userService;
        }
    }

    public class BaseViewModel<TParameter> : MvxViewModel where TParameter : class
    {
        protected IMvxNavigationService _navigationService;
        protected static IDataBaseService<Item> _itemService;
        protected static IDataBaseService<User> _userService;

        protected BaseViewModel(IMvxNavigationService navigationService, IDataBaseService<Item> itemService, IDataBaseService<User> userService)
        {
            _navigationService = navigationService;
            _itemService = itemService;
            _userService = userService;
        }
    }
}
