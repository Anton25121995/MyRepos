using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace HelloMvxForms.Converters
{
    public class FromPathToImageSourceConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (File.Exists((string)value))
            {
                return ImageSource.FromFile((string)value);
            }

            var uriString = "https://storage.googleapis.com/appconfig-media/appconfig-content/uploads/2016/04/xamarin-app-logo2.png";
            
            return ImageSource.FromUri(new Uri(uriString));
        }
    }
}
