using Android.Content;
using HelloMvxForms.Droid.Services;
using HelloMvxForms.Interfaces;
using MvvmCross.Binding.Droid;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace HelloMvxForms.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {

        }

        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new HelloMvxForms.App();
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.MvxApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterSingleton<IAlertService>(new AlertService_Android());
        }

        //protected override void InitializeLastChance()
        //{
        //    base.InitializeLastChance();

        //    var builder = new MvxAndroidBindingBuilder();
        //    builder.DoRegistration();
        //}
    }
}
