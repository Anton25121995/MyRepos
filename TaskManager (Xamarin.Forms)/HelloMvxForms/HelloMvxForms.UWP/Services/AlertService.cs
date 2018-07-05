using HelloMvxForms.Interfaces;
using HelloMvxForms.UWP.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AlertService_UWP))]
namespace HelloMvxForms.UWP.Services
{
    public class AlertService_UWP : IAlertService
    {
        public Task<bool> ShowAlertConfirmation(string message, string buttonYesTitle = "Yes", string buttonNoTitle = "No")
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string title, string message)
        {
            throw new NotImplementedException();
        }

        public bool ShowOkCancelMessage(string title, string message, Action onOk, Action onCancel)
        {
            throw new NotImplementedException();
        }

        public void ShowSingle(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowToast(string message)
        {
            throw new NotImplementedException();
        }
    }
}
