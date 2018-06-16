using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using TestProject.Core.ViewModels;
using System.ComponentModel;

namespace TestProject.Droid
{
    [Activity(Label = "TestProject", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(2130968620);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnStop()
        {
            OnRestart();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public virtual void OnViewModelChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

    }
}

