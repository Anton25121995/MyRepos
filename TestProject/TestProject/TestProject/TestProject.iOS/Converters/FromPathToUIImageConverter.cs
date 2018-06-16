using System;
using System.IO;
using System.Reflection;
using Foundation;
using MvvmCross.Platform.Converters;
using UIKit;

namespace TestProject.iOS.Converters
{
    public class FromPathToUIImageConverter : MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string str, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (File.Exists(str))
            {
                return UIImage.FromFile(str);
            }

            return UIImage.FromBundle("user.png");
        }
    }
}