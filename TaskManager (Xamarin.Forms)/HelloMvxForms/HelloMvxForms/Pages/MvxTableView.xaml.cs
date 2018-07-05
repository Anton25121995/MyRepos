using HelloMvxForms.Core.ViewModels;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;
using Xamarin.Forms;

namespace HelloMvxForms.Core.Views
{
    [MvxContentPagePresentation]
    public partial class MvxTableView : MvxContentPage<MvxTableViewModel>
    {
        public MvxTableView()
        {
            InitializeComponent();
            listView.IsEnabled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ToolbarItems.Remove(addButton);
            ToolbarItems.Add(addButton);
        }


        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.IsEnabled = false;
        }
    }
}