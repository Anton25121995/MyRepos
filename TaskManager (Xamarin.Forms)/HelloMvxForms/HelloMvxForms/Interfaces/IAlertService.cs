using System;
using System.Threading.Tasks;

namespace HelloMvxForms.Interfaces
{
    public interface IAlertService
    {
        void ShowSingle(string message);
        void ShowMessage(string title, string message);
        void ShowErrorMessage(Exception ex);
        bool ShowOkCancelMessage(string title, string message, Action onOk, Action onCancel);
        void ShowToast(string message);
        Task<bool> ShowAlertConfirmation(string message, string buttonYesTitle = "Yes", string buttonNoTitle = "No");
    }
}
