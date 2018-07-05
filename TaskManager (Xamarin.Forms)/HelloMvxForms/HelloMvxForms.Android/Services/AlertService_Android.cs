using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using HelloMvxForms.Droid.Services;
using HelloMvxForms.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AlertService_Android))]
namespace HelloMvxForms.Droid.Services
{
    public class AlertService_Android : IAlertService
    {
        public static Activity Activity { get; set; }

        public bool ShowAlertConfirmation(string message)
        {
            bool result = false;
            Activity.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Activity);

                alert.SetMessage(message);
                alert.SetPositiveButton("Delete", (senderAlert, args) => { result = true; });
                alert.SetNegativeButton("Cancel", (senderAlert, args) => { result = false; });

                Dialog dialog = alert.Create();
                dialog.ShowEvent += (s, e) =>
                {
                    result = true;
                };

                dialog.CancelEvent += (s, e) =>
                {
                    result = false;
                };
                dialog.Show();
            });
            return result;
        }

        public void ShowMessage(string title, string message)
        {

            Activity.RunOnUiThread(() =>
            {
                var alert = new AlertDialog.Builder(Activity);
                alert.SetTitle(title);
                alert.SetMessage(message);
                alert.SetPositiveButton("Ok", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            });

        }

        public void ShowErrorMessage(Exception ex)
        {
            Activity.RunOnUiThread(() =>
            {
                var alert = new Android.App.AlertDialog.Builder(Activity);
                alert.SetMessage(ex.Message);
                alert.SetPositiveButton("Ok", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public bool ShowOkCancelMessage(string title, string message, Action onOk, Action onCancel)
        {
            bool result = false;
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(Activity);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("Ok", (senderAlert, args) => onOk?.Invoke());
            alert.SetNegativeButton("Cancel", (senderAlert, args) => onCancel?.Invoke());
            Dialog dialog = alert.Create();
            dialog.Show();
            return result;
        }

        public void ShowSingle(string message)
        {
            Activity.RunOnUiThread(() =>
            {
                var alert = new Android.App.AlertDialog.Builder(Activity);
                alert.SetMessage(message);
                alert.SetPositiveButton("Ok", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            });
        }

        public void ShowSingle(string message, Activity activity)
        {
            Activity.RunOnUiThread(() =>
            {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(activity);
                alert.SetMessage(message);
                alert.SetPositiveButton("Ok", (senderAlert, args) => { });
                Dialog dialog = alert.Create();
                dialog.Show();
            });

        }

        public void ShowToast(string message, Activity activity)
        {
            Activity.RunOnUiThread(() =>
            {
                Toast.MakeText(activity, message, ToastLength.Long).Show();
            });
        }

        public void ShowToast(string message)
        {
            Activity.RunOnUiThread(() =>
            {
                Toast.MakeText(Activity, message, ToastLength.Long).Show();
            });
        }

        public Task<bool> ShowAlertConfirmation(string message, string buttonYesTitle = "Yes", string buttonNoTitle = "No")
        {
            var tcs = new TaskCompletionSource<bool>();

            Activity.RunOnUiThread(() =>
            {
                var alert = new Android.App.AlertDialog.Builder(Activity);

                alert.SetMessage(message);
                alert.SetPositiveButton(buttonYesTitle, (senderAlert, args) =>
                {
                    tcs.SetResult(true);
                });
                alert.SetNegativeButton(buttonNoTitle, (senderAlert, args) =>
                {
                    tcs.SetResult(false);
                });
                Dialog dialog = alert.Create();

                dialog.Show();
            });

            return tcs.Task;
        }
    }
}
