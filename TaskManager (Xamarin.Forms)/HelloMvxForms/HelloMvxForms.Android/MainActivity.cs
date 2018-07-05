using Android.App;
using Android.Content.PM;
using Android.OS;
using HelloMvxForms.Droid.Services;
using MvvmCross.Forms.Droid.Views;
using Plugin.CurrentActivity;

namespace HelloMvxForms.Droid
{
    [Activity(
        Label = "HelloMvxForms",
        Icon = "@drawable/app",
        Theme = "@style/MainTheme",

        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AlertService_Android.Activity = this;
            Instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            CrossCurrentActivity.Current.Init(this, bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
