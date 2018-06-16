using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProject.Core
{
    public static class Constant
    {
        public static readonly string DbFilePath =
        Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "table.db"
        );

        public static readonly string ImageFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Images"
        );

        public static readonly string IconsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Icons"
        );
    }
}
