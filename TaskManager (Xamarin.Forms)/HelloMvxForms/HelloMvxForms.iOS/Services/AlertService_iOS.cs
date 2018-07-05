using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Foundation;
using HelloMvxForms.Interfaces;
using HelloMvxForms.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AlertService_iOS))]
namespace HelloMvxForms.iOS.Services
{
    public class AlertService_iOS : IAlertService
    {
        public AlertService_iOS()
        {

        }
        public void ShowToast(string title, string message)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = title,
                    Message = message
                };
                alert.AddButton("Ok");
                alert.Show();
            });
        }

        public bool ShowOkCancelMessage(string title, string message, Action onOk, Action onCancel)
        {
            var result = false;
            UIAlertView alert = new UIAlertView()
            {
                Title = title,
                Message = message

            };
            alert.AddButton("Ok");
            alert.AddButton("Cancel");

            alert.Clicked += (object s, UIButtonEventArgs e) =>
            {
                if (e.ButtonIndex == 0)
                {
                    onOk?.Invoke();
                }
                if (e.ButtonIndex == 1)
                {
                    onCancel?.Invoke();
                }
            };
            alert.Show();
            return result;
        }

        public void ShowErrorMessage(Exception exception)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                try
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Message = exception.Message
                    };
                    alert.AddButton("Ok");
                    alert.Show();
                }
                catch (Exception)
                {
                }
            });
        }

        public void ShowSingle(string message)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                try
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Message = message
                    };
                    alert.AddButton("Ok");
                    alert.Show();
                }
                catch (Exception ex)
                {
                }
            });
        }

        public void ShowSingleWithTimeout(string message, int seconds)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Message = message,
                    Alpha = 1.0f
                };
                NSTimer tmr;
                alert.Show();

                tmr = NSTimer.CreateTimer(seconds, delegate
                {
                    alert.DismissWithClickedButtonIndex(0, true);
                    alert = null;
                });
                NSRunLoop.Main.AddTimer(tmr, NSRunLoopMode.Common);
            });
        }

        [DllImport("__Internal", EntryPoint = "exit")]
        public static extern void Exit(int status);
        public void ShowMessage(string title, string message)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = title,
                    Message = message
                };
                alert.AddButton("Ok");
                alert.Show();
            });
        }

        public void ShowToast(string message)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Message = message
                };
                alert.AddButton("Ok");
                alert.Show();
            });
        }

        public Task<bool> ShowAlertConfirmation(string message, string buttonYesTitle = "Yes", string buttonNoTitle = "No")
        {
            var tcs = new TaskCompletionSource<bool>();

            UIApplication.SharedApplication.InvokeOnMainThread(new Action(() =>
            {
                UIAlertView alert = new UIAlertView()
                {
                    Message = message
                };

                var yesIndex = alert.AddButton(buttonYesTitle);
                var noIndex = alert.AddButton(buttonNoTitle);

                alert.Clicked += (sender, buttonArgs) => tcs.SetResult(buttonArgs.ButtonIndex == yesIndex);
                alert.Show();
            }));

            return tcs.Task;
        }
    }
}