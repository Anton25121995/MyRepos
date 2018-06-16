using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using MvvmCross.Core.ViewModels;
using TestProject.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace TestProject.iOS.ViewControllers.Base
{
    public class BaseViewController<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IMvxViewModel
    {
        #region Properties

        protected virtual bool LoaderVisible { get; } = false;
        protected BaseViewModel BaseViewModel { get { return ViewModel as BaseViewModel; } }

        #endregion

        public BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
            
        }

        #region Lifecycle

        #endregion
    }


}