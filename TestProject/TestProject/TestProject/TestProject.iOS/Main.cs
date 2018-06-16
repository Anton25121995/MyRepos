using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TestProject.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MAINERROR: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
