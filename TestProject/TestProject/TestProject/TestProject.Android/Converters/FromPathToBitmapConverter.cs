using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace TestProject.Droid.Converters
{
    public class FromPathToBitmapConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (File.Exists((string)value))
            {
                return BitmapFactory.DecodeFile((string)value);
            }

            return BitmapFactory.DecodeResource(Resources.System, (int)Resource.Id.icon);
        }
    }
}