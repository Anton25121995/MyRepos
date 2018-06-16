using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using TestProject.Droid.Converters;

namespace TestProject.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void FillValueConverters(MvvmCross.Platform.Converters.IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            
            registry.AddOrOverwrite("FromPathToBitmap", new FromPathToBitmapConverter());

        }
    }
}