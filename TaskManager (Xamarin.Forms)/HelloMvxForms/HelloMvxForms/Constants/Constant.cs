using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloMvxForms.Constants
{
    public static class Constant
    {

        public static readonly string DbFilePath =
        Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Database.db"
        );

        public static readonly string ImageFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Images"
        );

        public static readonly string IconsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Icons"
        );

        public static readonly string PickFromCamera = "From Camera";
        public static readonly string PickFromGallery = "From Gallery";
        public static readonly string CancelPicking= "Cancel";
    }
}
