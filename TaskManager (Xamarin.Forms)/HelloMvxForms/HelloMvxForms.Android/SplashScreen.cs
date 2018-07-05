using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;
using Felipecsl.GifImageViewLibrary;
using MvvmCross.Droid.Views;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HelloMvxForms.Droid
{
    [Activity(
        Label = "HelloMvxForms"
        , Icon = "@drawable/app"
        , Theme = "@style/Theme.Splash"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {

        }

        protected override void TriggerFirstNavigate()
        {
            StartActivity(typeof(MainActivity));
            base.TriggerFirstNavigate();
            OnEnterAnimationComplete();
        }
    }
}
